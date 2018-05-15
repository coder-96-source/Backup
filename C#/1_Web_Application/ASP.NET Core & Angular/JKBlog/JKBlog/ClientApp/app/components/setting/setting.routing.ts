import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TopicTableComponent } from './topic-table/topic-table.component'
import { ArticleTableComponent } from './article-table/article-table.component';
import { AnnouncementTableComponent } from './announcement-table/announcement-table.component';

export const AdminRouterModule: ModuleWithProviders = RouterModule.forChild([
    {
        path: 'admin', children: [
            { path: 'topic', component: TopicTableComponent },
            { path: 'article', component: ArticleTableComponent },
            { path: 'announcement', component: AnnouncementTableComponent }
        ]
    },
]);