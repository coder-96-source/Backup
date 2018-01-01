import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Article } from '../../models/dataModel/article';

@Component({
    selector: 'app-article',
    templateUrl: './article.component.html',
    styleUrls: ['./article.component.css']
})

export class ArticleComponent {
    title = 'Article'
    articles: Article[];
    selectedArticle: Article;

    constructor(http: Http) {
        http.get('api/Home/GetArticles').subscribe(a => {
            this.articles = a.json();
        });
    }

    ngOnInit() {

    }

    onSelect(article: Article): void {
        this.selectedArticle = article;
        this.selectedArticle.visible = true;
    }

    //navigate(forward: any) {
    //    var index = this.articles.indexOf(this.selectedArticle) + (forward ? 1 : -1);
    //    if (index >= 0 && index < this.articles.length) {
    //        this.selectedArticle = this.articles[index];
    //    }
    //}
}
