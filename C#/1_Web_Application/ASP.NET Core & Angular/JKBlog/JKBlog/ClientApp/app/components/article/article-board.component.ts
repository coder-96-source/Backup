import { Component, OnInit } from '@angular/core';
import { Article } from '../../models/dataModel/article';
import { ArticleCardService } from '../../services/article-card.service';

@Component({
    selector: 'app-article-board',
    templateUrl: './article-board.component.html',
    styleUrls: ['./article-board.component.css']
})

export class ArticleBoardComponent {
    articles: Article[];
    errorMessage: string;

    constructor(private articleCardService: ArticleCardService) {

    }

    ngOnInit() {
        this.fetchArticles().subscribe(res => this.articles = res,
            error => this.errorMessage = error as string);
    }

    fetchArticles() {
        return this.articleCardService.getArticles();
    }
}
