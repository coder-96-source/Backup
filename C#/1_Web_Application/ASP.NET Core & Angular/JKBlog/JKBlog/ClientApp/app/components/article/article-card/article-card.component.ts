import { Component, OnInit } from '@angular/core';
import { Article } from '../../../models/dataModel/article';
import { ArticleCardService } from '../../../services/article-card.service';

@Component({
    selector: 'app-article-card',
    templateUrl: './article-card.component.html',
    styleUrls: ['./article-card.component.css']
})

export class ArticleCardComponent {
    title = 'Article'
    articles: Article[];
    selectedArticle: Article;
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
