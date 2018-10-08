import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Article } from '../../../../../models/article';
import { ArticleService } from '../../../../../services/main/home/article.service';
import { SnackbarService, SnackbarAction } from '../../../../../services/shared/snackbar.service';

@Component({
  selector: 'app-article-detail',
  templateUrl: './article-detail.component.html',
  styleUrls: ['./article-detail.component.scss']
})

export class ArticleDetailComponent implements OnInit {
  private isLoaded = false;
  private article?: Article;
  private commentPageId?: string;

  constructor(
    private route: ActivatedRoute,
    private articleService: ArticleService,
    private snackbarService: SnackbarService) {

  }

  ngOnInit() {
    this.initializeArticle();
  }

  fetchArticle() {
    const id = this.route.snapshot.paramMap.get('id');
    this.commentPageId = '/article/' + id;
    return this.articleService.getArticle(id);
  }

  initializeArticle() {
    this.fetchArticle().subscribe(res => {
      this.article = res as Article;
      this.isLoaded = true;
    },
      error => {

      });
  }
}
