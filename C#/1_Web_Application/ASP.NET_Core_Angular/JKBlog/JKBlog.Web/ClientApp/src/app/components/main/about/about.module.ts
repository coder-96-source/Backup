import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
    MatTabsModule,
    MatCardModule,
    MatButtonModule,
    MatProgressSpinnerModule,
} from '@angular/material';
import { SharedModule } from '../../../shared.module';

import { AboutRoutingModule } from './about.routing';

import { AboutComponent } from './about.component'
import { AboutSummaryComponent } from './about-summary/about-summary.component';
import { AboutFrontendComponent } from './about-frontend/about-frontend.component';
import { AboutBackendComponent } from './about-backend/about-backend.component';

import { AboutService } from '../../../services/main/about/about.service';

@NgModule({
    declarations: [
        AboutComponent,
        AboutSummaryComponent,
        AboutFrontendComponent,
        AboutBackendComponent
    ],
    imports: [
        CommonModule,
      BrowserAnimationsModule,
        FlexLayoutModule,
        MatTabsModule,
        MatCardModule,
        MatButtonModule,
        MatProgressSpinnerModule,
        SharedModule,

        AboutRoutingModule
    ],
    exports: [
        AboutComponent
    ],
    providers: [
      AboutService
    ]
})
export class AboutModule { }
