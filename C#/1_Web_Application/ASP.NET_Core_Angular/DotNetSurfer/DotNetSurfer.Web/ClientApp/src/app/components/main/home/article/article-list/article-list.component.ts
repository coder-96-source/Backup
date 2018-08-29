import { Component, OnInit } from '@angular/core';
import { Article } from '../../../../../models/article';
import { ArticleCardService } from '../../../../../services/main/home/article-card.service';
import { LoggingService } from '../../../../../services/shared/logging.service';
import { SnackbarService, SnackbarAction } from '../../../../../services/shared/snackbar.service';

@Component({
  selector: 'app-article-list',
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.scss']
})

export class ArticleListComponent {
  private readonly contentDisplayLength = 50; // Content string length to show
  private page = 1;
  private isLoaded = false;
  private isAllLoaded = false;
  private isExpanded = true;
  private articles?: Article[];

  constructor(
    private articleCardService: ArticleCardService,
    private loggingService: LoggingService,
    private snackbarService: SnackbarService) {

  }

  ngOnInit() {
    this.initializeArticles();
  }

  fetchArticles() {
    return this.articleCardService.getArticlesByPage(this.page++);
  }

  initializeArticles() {
    this.fetchArticles().subscribe(res => {
      this.articles = res as Article[];
      this.isLoaded = true;
    },
      error => {
        const errorMessage = error as string;
        this.loggingService.writeErrorLog(errorMessage);
        this.snackbarService.openSnackBar(errorMessage, SnackbarAction.Error);
      });
  }

  expandArticles() {
    this.isExpanded = false;
    this.fetchArticles().subscribe(res => {
      const loadedArticles = res as Article[];
      if (loadedArticles.length <= 0) {
        this.isAllLoaded = true;
      }
      this.articles = this.articles!.concat(loadedArticles);
      this.isExpanded = true;
    });
  }
}
