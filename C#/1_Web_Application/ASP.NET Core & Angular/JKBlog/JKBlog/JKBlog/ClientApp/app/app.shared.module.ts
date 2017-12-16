import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';


import { AppComponent } from './components/app/app.component';
import { NavComponent } from './components/nav/nav.component';
import { HomeComponent } from './components/home/home.component';
import { BannerComponent } from './components/banner/banner.component';
import { AboutComponent } from './components/about/about.component';
import { ContactComponent } from './components/contact/contact.component';
import { ArticleBoardComponent } from './components/articleBoard/articleBoard.component';

import { ArticleAnimationComponent } from './components/articleAnimation/articleAnimation.component';


@NgModule({
    declarations: [
        AppComponent,
        NavComponent,
        HomeComponent,
        BannerComponent,
        AboutComponent,
        ContactComponent,
        ArticleBoardComponent,

        ArticleAnimationComponent
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
