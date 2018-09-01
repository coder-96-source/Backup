import { Injectable } from '@angular/core';
import { GatewayService } from '../../shared/gateway.service';

@Injectable()
export class ArticleService {

  constructor(private gateway: GatewayService) {

  }

  getArticles() {
    return this.gateway.get('api/articles');
  }

  getArticlesByPage(page: number) {
    return this.gateway.get(`api/articles/page/${page}`);
  }

  getArticle(articleId: any) {
    return this.gateway.get(`api/articles/${articleId}`);
  }
} 
