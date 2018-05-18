import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ArticleDetailComponent } from './article-card/article-detail/article-detail.component';

const routes: Routes = [
  { path: 'article/:id', component: ArticleDetailComponent }
];

@NgModule({
  imports: [ RouterModule.forChild(routes) ],
  exports: [ RouterModule ]
})
export class ArticleRoutingModule {}

//import { ModuleWithProviders } from '@angular/core';
//import { RouterModule } from '@angular/router';
//import { ArticleDetailComponent } from './article-card/article-detail/article-detail.component';

//export const ArticleRoutingModule: ModuleWithProviders = RouterModule.forChild([
//    {
//        path: 'article/:id', component: ArticleDetailComponent
//    }
//]);