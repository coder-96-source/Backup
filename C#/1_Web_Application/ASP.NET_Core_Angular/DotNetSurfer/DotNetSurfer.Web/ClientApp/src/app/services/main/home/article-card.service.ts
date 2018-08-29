import { Injectable } from '@angular/core';
import { Article } from '../../../models//article';
import { GatewayService } from '../../shared/gateway.service';

@Injectable()
export class ArticleCardService {
    constructor(private gateway: GatewayService) {

    }

    getArticles() {
        return this.gateway.get('api/articles');
    }

    getArticlesByPage(page: number) {
        return this.gateway.get(`api/articles/page/${page}`);
    }
} 
