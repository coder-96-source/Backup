import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminRouterModule } from './setting.routing';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpModule, BaseRequestOptions, Headers, RequestOptions } from '@angular/http';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FileUploadModule } from 'ng2-file-upload';
import { QuillModule } from 'ngx-quill';
import { UserService } from '../../services/user.service';
import { TopicTableService } from '../../services/admin/topic-table.service';
import { TopicDialogService } from '../../services/admin/topic-dialog.service';
import { ArticleTableService } from '../../services/admin/article-table.service';
import { ArticleDialogService } from '../../services/admin/article-dialog.service';
import { AnnouncementTableService } from '../../services/admin/announcement-table.service';
import { AnnouncementDialogService } from '../../services/admin/announcement-dialog.service';
import { GatewayService } from '../../services/gateway.service';
import { JWTGatewayService } from '../../services/jwtgateway.service';
import { CdkTableModule } from '@angular/cdk/table';
import { TopicTableComponent } from './topic-table/topic-table.component';
import { TopicDialogComponent } from './topic-table/topic-dialog/topic-dialog.component';
import { ArticleTableComponent } from './article-table/article-table.component';
import { ArticleDialogComponent } from './article-table/article-dialog/article-dialog.component';
import { AnnouncementTableComponent } from './announcement-table/announcement-table.component';
import { AnnouncementDialogComponent } from './announcement-table/announcement-dialog/announcement-dialog.component';
import { PictureUploaderComponent } from './picture-uploader/picture-uploader.component';
import { EditorComponent } from './editor/editor.component';

import {   
    MatAutocompleteModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatStepperModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule
} from '@angular/material';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        AdminRouterModule,
        BrowserModule,
        HttpModule,
        BrowserAnimationsModule,
        FlexLayoutModule,
        CdkTableModule,
        MatAutocompleteModule,
        MatButtonModule,
        MatButtonToggleModule,
        MatCardModule,
        MatCheckboxModule,
        MatChipsModule,
        MatDatepickerModule,
        MatDialogModule,
        MatDividerModule,
        MatExpansionModule,
        MatGridListModule,
        MatIconModule,
        MatInputModule,
        MatListModule,
        MatMenuModule,
        MatNativeDateModule,
        MatPaginatorModule,
        MatProgressBarModule,
        MatProgressSpinnerModule,
        MatRadioModule,
        MatRippleModule,
        MatSelectModule,
        MatSidenavModule,
        MatSliderModule,
        MatSlideToggleModule,
        MatSnackBarModule,
        MatSortModule,
        MatStepperModule,
        MatTableModule,
        MatTabsModule,
        MatToolbarModule,
        MatTooltipModule,
        FileUploadModule,
        QuillModule
    ],
    declarations: [TopicTableComponent, TopicDialogComponent, ArticleTableComponent, ArticleDialogComponent,
        AnnouncementTableComponent, AnnouncementDialogComponent, PictureUploaderComponent, EditorComponent],
    providers: [UserService, TopicTableService, TopicDialogService, ArticleTableService, ArticleDialogService
        , AnnouncementTableService, AnnouncementDialogService, GatewayService, JWTGatewayService
    ],
    entryComponents: [TopicDialogComponent, ArticleDialogComponent, AnnouncementDialogComponent]
})
export class SettingModule {
}