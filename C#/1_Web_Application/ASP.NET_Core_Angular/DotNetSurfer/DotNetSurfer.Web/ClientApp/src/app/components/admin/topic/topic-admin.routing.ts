import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { TopicTableComponent } from './topic-table/topic-table.component';

const routes: Routes = [
  {
    path: 'admin', children: [
      { path: 'topic', component: TopicTableComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TopicAdminRoutingModule { }
