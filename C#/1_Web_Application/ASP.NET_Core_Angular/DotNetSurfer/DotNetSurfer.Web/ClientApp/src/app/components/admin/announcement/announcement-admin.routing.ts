import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AnnouncementTableComponent } from './announcement-table/announcement-table.component';

const routes: Routes = [
  {
    path: 'admin', children: [
      { path: 'announcement', component: AnnouncementTableComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AnnouncementAdminRoutingModule { }
