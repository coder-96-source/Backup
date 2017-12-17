import { Component, OnInit } from '@angular/core';
import { Article } from '../../models/article';
import { ARTICLES } from '../../models/mock-articles';

@Component({
    selector: 'articleBoard',
    templateUrl: './articleBoard.component.html',
    styleUrls: ['./articleBoard.component.css']
})

export class ArticleBoardComponent {
    title = 'Article'
    articles = ARTICLES;

    selectedArticle: Article;

    constructor() { }

    ngOnInit() {

    }

    onSelect(article: Article): void {
        this.selectedArticle = article;
        this.selectedArticle.visible = true;
    }

    navigate(forward: any) {
        var index = this.articles.indexOf(this.selectedArticle) + (forward ? 1 : -1);
        if (index >= 0 && index < this.articles.length) {
            this.selectedArticle = this.articles[index];
        }
    }
}
