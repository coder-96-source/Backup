import { Component, OnInit } from '@angular/core';
import { Article } from '../../../../../models/article';
import { ArticleCardService } from '../../../../../services/main/home/article-card.service';

@Component({
    selector: 'app-article-card',
    templateUrl: './article-card.component.html',
    styleUrls: ['./article-card.component.scss']
})

export class ArticleCardComponent {
    private readonly articleDisplayLimit = 3; // Article number to show
    private readonly contentDisplayLength = 50; // Content string length to show
    private isLoaded = false;
    private articles?: Article[];
    private errorMessage?: string;

    constructor(private articleCardService: ArticleCardService) {

    }

    ngOnInit() {
        this.fetchArticles().subscribe(res => {
            this.articles = res as Article[];
            if (this.articles.length > this.articleDisplayLimit) {
                this.articles = this.articles.slice(0, this.articleDisplayLimit); // Show only limited number of article      
            }
            this.isLoaded = true;
        },
            error => this.errorMessage = error as string)
    }

    fetchArticles() {
        return this.articleCardService.getArticles();
    }
}
