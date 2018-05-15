import { Injectable } from '@angular/core';
import { Article } from '../../models/dataModel/Article';
import { User } from '../../models/dataModel/user';
import { UserService } from '../user.service';
import { JWTGatewayService } from '../jwtgateway.service';

@Injectable()
export class ArticleDialogService {

    constructor(private userService: UserService,
        private jwtGateway: JWTGatewayService) {
    }

    getArticle(articleId: number) {
        return this.jwtGateway.get(`api/Admin/Article/${articleId}`);
    }

    createArticle(article: Article) {
        //const userId = Number(localStorage.getItem('userId'));
        const user = this.userService.getUser as User;
        article.userId = user.userId;

        return this.jwtGateway.post('api/Admin/Article/Create', article);
    }

    updateArticle(article: Article) {
        return this.jwtGateway.put(`api/Admin/Article/Update/${article.articleId}`, article);
    }

    deleteArticle(articleId: number) {
        return this.jwtGateway.delete(`api/Admin/Article/Delete/${articleId}`);
    }
}
