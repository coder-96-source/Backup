import { Component, OnInit } from '@angular/core';
import { Article } from '../../../../../models/article';
import { ArticleCardService } from '../../../../../services/main/home/article-card.service';

@Component({
    selector: 'app-article-list',
    templateUrl: './article-list.component.html',
    styleUrls: ['./article-list.component.scss']
})

export class ArticleListComponent {
    private page = 1;
    private readonly contentDisplayLength = 50; // Content string length to show
    private isLoaded = false;
    private isAllLoaded = false;
    private isExpanded = true;
    private articles?: Article[];

    constructor(private articleCardService: ArticleCardService) {

    }

    ngOnInit() {
        this.fetchArticles().subscribe(res => {
            this.articles = res as Article[];
            this.isLoaded = true;
        });
    }

    fetchArticles() {
        return this.articleCardService.getArticlesByPage(this.page++);
    }

    expandArticles() {
        this.isExpanded = false;
        this.fetchArticles().subscribe(res => {
            const loadedArticles = res as Article[];
            if (loadedArticles.length <= 0) {
                this.isAllLoaded = true;
            }
            this.articles = this.articles!.concat(loadedArticles);
            this.isExpanded = true;
        });
    }
}
