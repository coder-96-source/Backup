import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FlexLayoutModule } from '@angular/flex-layout';
import { DisqusModule } from "ngx-disqus";
import {
  MatButtonModule,
  MatCardModule,
  MatDividerModule,
  MatProgressSpinnerModule,
  MatIconModule
} from '@angular/material';
import { SharedModule } from '../../../../shared.module';

import { ArticleCardComponent } from './article-card/article-card.component';
import { ArticleListComponent } from './article-list/article-list.component';
import { ArticleDetailComponent } from './article-detail/article-detail.component';
import { CommentComponent } from './article-detail/comment/comment.component';

import { ArticleCardService } from '../../../../services/main/home/article-card.service';
import { ArticleDetailService } from '../../../../services/main/home/article-detail.service';

import { ArticleRoutingModule } from './article.routing';

@NgModule({
  declarations: [
    ArticleCardComponent,
    ArticleListComponent,
    ArticleDetailComponent,
    CommentComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    FlexLayoutModule,
    DisqusModule.forRoot('jkblog-com-1'),
    MatButtonModule,
    MatCardModule,
    MatDividerModule,
    MatProgressSpinnerModule,
    MatIconModule,
    SharedModule,
    ArticleRoutingModule
  ],
  exports: [
    ArticleCardComponent,
    ArticleListComponent
  ],
  providers: [
    ArticleCardService,
    ArticleDetailService
  ]
})
export class ArticleModule { }
