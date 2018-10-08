import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ArticleTableComponent } from './article-table/article-table.component';

const routes: Routes = [
  {
    path: 'admin', children: [
      { path: 'article', component: ArticleTableComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ArticleAdminRoutingModule { }
