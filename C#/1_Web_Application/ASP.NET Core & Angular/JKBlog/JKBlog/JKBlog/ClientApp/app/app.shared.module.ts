import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // Animation
import { ReactiveFormsModule } from '@angular/forms'; // Animation

import { AppComponent } from './components/app/app.component';
import { NavComponent } from './components/nav/nav.component';
import { HomeComponent } from './components/home/home.component';
import { BannerComponent } from './components/banner/banner.component';
import { AboutComponent } from './components/about/about.component';
import { ContactComponent } from './components/contact/contact.component';
import { ArticleComponent } from './components/article/article.component';

import { ArticlePopupComponent } from './components/article-popup/article-popup.component'; // Animation


@NgModule({
    declarations: [
        AppComponent,
        NavComponent,
        HomeComponent,
        BannerComponent,
        AboutComponent,
        ContactComponent,
        ArticleComponent,

        ArticlePopupComponent // Animation
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

        BrowserAnimationsModule

    ]
})
export class AppModuleShared {
}
