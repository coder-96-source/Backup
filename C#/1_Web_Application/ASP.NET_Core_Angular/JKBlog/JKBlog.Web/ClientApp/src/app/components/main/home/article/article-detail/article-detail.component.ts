import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Article } from '../../../../../models/article';
import { ArticleDetailService } from '../../../../../services/main/home/article-detail.service';
import { LoggingService } from '../../../../../services/shared/logging.service';
import { SnackbarService, SnackbarAction } from '../../../../../services/shared/snackbar.service';

@Component({
  selector: 'app-article-detail',
  templateUrl: './article-detail.component.html',
  styleUrls: ['./article-detail.component.scss']
})

export class ArticleDetailComponent {
  private article?: Article;
  private commentPageId?: string;

  constructor(
    private route: ActivatedRoute,
    private articleDetailService: ArticleDetailService,
    private loggingService: LoggingService,
    private snackbarService: SnackbarService) {

  }

  ngOnInit() {
    this.initializeArticles();
  }

  fetchArticle() {
    const id = this.route.snapshot.paramMap.get('id');
    this.commentPageId = '/article/' + id;
    return this.articleDetailService.getArticle(id);
  }

  initializeArticles() {
    this.fetchArticle().subscribe(res => {
      this.article = res as Article;
    },
      error => {
        const errorMessage = error as string;
        this.loggingService.writeErrorLog(errorMessage);
        this.snackbarService.openSnackBar(errorMessage, SnackbarAction.Error);
      });
  }
}
