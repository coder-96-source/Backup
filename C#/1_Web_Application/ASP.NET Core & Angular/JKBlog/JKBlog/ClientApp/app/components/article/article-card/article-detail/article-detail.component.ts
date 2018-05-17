import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Article } from '../../../../models/dataModel/article';
import { ArticleDetailService } from '../../../../services/article-detail.service';

@Component({
    selector: 'app-article-detail',
    templateUrl: './article-detail.component.html',
    styleUrls: ['./article-detail.component.scss']
})

export class ArticleDetailComponent {
    //title = 'Article'
    article: Article;
    errorMessage: string;

    constructor(
        private route: ActivatedRoute,
        private articleDetailService: ArticleDetailService,
        private location: Location) {

    }

    ngOnInit() {
        this.fetchArticle();
    }

    fetchArticle() {
        const id = this.route.snapshot.paramMap.get('id');
        this.articleDetailService.getArticle(id)
            .subscribe(res => this.article = res as Article,
            error => this.errorMessage = error as string);
    }

    goBack(): void {
        this.location.back();
    }
}
