import { Component, OnInit } from '@angular/core';
import { Article } from '../../../../../models/article';
import { ArticleService } from '../../../../../services/main/home/article.service';
import { LoggingService } from '../../../../../services/shared/logging.service';
import { SnackbarService, SnackbarAction } from '../../../../../services/shared/snackbar.service';

@Component({
  selector: 'app-article-card',
  templateUrl: './article-card.component.html',
  styleUrls: ['./article-card.component.scss']
})

export class ArticleCardComponent implements OnInit{
  private readonly articleDisplayLimit = 3; // Article number to show
  private readonly contentDisplayLength = 50; // Content string length to show
  private isLoaded = false;
  private articles?: Article[];

  constructor(
    private articleService: ArticleService,
    private loggingService: LoggingService,
    private snackbarService: SnackbarService) {

  }

  ngOnInit() {
    this.initializeArticles();
  }

  fetchArticles() {
    return this.articleService.getArticles();
  }

  initializeArticles() {
    this.fetchArticles().subscribe(res => {
      this.articles = res as Article[];
      if (this.articles.length > this.articleDisplayLimit) {
        this.articles = this.articles.slice(0, this.articleDisplayLimit); // Show only limited number of article      
      }
      this.isLoaded = true;
    },
      error => {
        const errorMessage = error as string;
        this.loggingService.writeErrorLog(errorMessage);
        this.snackbarService.openSnackBar(errorMessage, SnackbarAction.Error);
      });
  }
}
