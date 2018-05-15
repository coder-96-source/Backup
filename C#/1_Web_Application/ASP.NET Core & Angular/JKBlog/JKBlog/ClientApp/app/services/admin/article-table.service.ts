import { Injectable } from '@angular/core';
import { Article } from '../../models/dataModel/Article';
import { JWTGatewayService } from '../jwtgateway.service';

@Injectable()
export class ArticleTableService {

    constructor(private jwtGateway: JWTGatewayService) {

    }

    getArticles() {
        return this.jwtGateway.get('api/Admin/Articles');
    }
} 