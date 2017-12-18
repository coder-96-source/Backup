import { Component, OnInit } from '@angular/core';
import { ArticleVM } from '../../viewModels/articleVM';
import { ARTICLES } from '../../viewModels/mock-articles';

@Component({
    selector: 'app-article',
    templateUrl: './article.component.html',
    styleUrls: ['./article.component.css']
})

export class ArticleComponent {
    title = 'Article'
    articles = ARTICLES;

    selectedArticle: ArticleVM;

    constructor() { }

    ngOnInit() {

    }

    onSelect(article: ArticleVM): void {
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
