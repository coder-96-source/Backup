import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // Animation
import { ReactiveFormsModule } from '@angular/forms'; // Animation
import { UserModule } from './components/user/user.module';

import { AppComponent } from './components/app/app.component';
import { NavComponent } from './components/nav/nav.component';
import { HomeComponent } from './components/home/home.component';
import { BannerComponent } from './components/banner/banner.component';
import { ArticleComponent } from './components/article/article.component'
import { ArticlePopupComponent } from './components/article-popup/article-popup.component'; // Animation
import { AnnouncementComponent } from './components/announcement/announcement.component';
import { AboutComponent } from './components/about/about.component';
import { ContactComponent } from './components/contact/contact.component';


@NgModule({
    declarations: [
        AppComponent,
        NavComponent,
        HomeComponent,
        BannerComponent,
        ArticleComponent,
        ArticlePopupComponent, // Animation
        AnnouncementComponent,
        AboutComponent,
        ContactComponent,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'about', component: AboutComponent },
            { path: 'contact', component: ContactComponent },

            { path: '**', redirectTo: 'home' }
        ]),

        BrowserAnimationsModule, // Animation
        UserModule
    ]
})
export class AppModuleShared {
}
