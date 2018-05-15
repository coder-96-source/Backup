import { Injectable } from '@angular/core';
import { Article } from '../models/dataModel/article';
import { GatewayService } from './gateway.service';

@Injectable()
export class ArticleCardService {
    constructor(private gateway: GatewayService) {

    }

    getArticles() {
        return this.gateway.get('api/Home/Articles');
    }
} 