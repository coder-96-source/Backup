import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Article } from '../../../../../models/article';
import { ArticleDetailService } from '../../../../../services/main/home/article-detail.service';

@Component({
    selector: 'app-article-detail',
    templateUrl: './article-detail.component.html',
    styleUrls: ['./article-detail.component.scss']
})

export class ArticleDetailComponent {
    private article?: Article;
    private commentPageId?: string;

    constructor(
        private route: ActivatedRoute,
        private articleDetailService: ArticleDetailService) {

    }

    ngOnInit() {
        this.fetchArticle();
    }

    fetchArticle() {
        const id = this.route.snapshot.paramMap.get('id');
        this.commentPageId = '/article/' + id;
        this.articleDetailService.getArticle(id)
            .subscribe(res => {
                this.article = res as Article;
            });
    }
}
