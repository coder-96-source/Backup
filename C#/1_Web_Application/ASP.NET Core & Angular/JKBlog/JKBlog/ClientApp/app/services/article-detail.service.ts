import { Injectable } from '@angular/core';
import { Article } from '../models/dataModel/article';
import { GatewayService } from './gateway.service';

@Injectable()
export class ArticleDetailService {
    constructor(private gateway: GatewayService) {

    }

    getArticle(articleId: any) {
        return this.gateway.get(`api/Home/Article/${articleId}`);
    }
} 