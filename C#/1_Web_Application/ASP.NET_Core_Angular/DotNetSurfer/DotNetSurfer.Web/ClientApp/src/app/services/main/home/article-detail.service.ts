import { Injectable } from '@angular/core';
import { Article } from '../../../models/article';
import { GatewayService } from '../../../services/shared/gateway.service';

@Injectable()
export class ArticleDetailService {
    constructor(private gateway: GatewayService) {

    }

    getArticle(articleId: any) {
        return this.gateway.get(`api/articles/${articleId}`);
    }
} 
