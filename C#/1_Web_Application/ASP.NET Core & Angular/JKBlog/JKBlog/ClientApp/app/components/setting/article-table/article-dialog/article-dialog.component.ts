import { Component, Input, OnInit, NgModule } from '@angular/core';
import { MatDialogRef, MatSnackBar } from '@angular/material';
import { Article } from '../../../../models/dataModel/article';
import { Topic } from '../../../../models/dataModel/topic';
import { ArticleDialogService } from '../../../../services/admin/article-dialog.service';
import { TopicTableService } from '../../../../services/admin/topic-table.service';
import { PictureUploaderComponent } from '../../picture-uploader/picture-uploader.component';
import { EditorComponent } from '../../editor/editor.component';

@Component({
    selector: 'app-admin-article-dialog',
    templateUrl: './article-dialog.component.html',
    //styleUrls: ['./article-dialog.component.css']
})

export class ArticleDialogComponent implements OnInit {
    public isAddMode: boolean;
    public articleId: number;
    private article: Article;
    private topics: Topic[]; // for select list

    constructor(
        private articleDialogService: ArticleDialogService,
        private topicTableService: TopicTableService,
        private dialogRef: MatDialogRef<ArticleDialogComponent>,
        private snackBar: MatSnackBar
    ) { }

    ngOnInit() {
        this.article = new Article(); // to avoid null reference
        this.getarticles(); // get select list
        if (!this.isAddMode) { // Edit mode
            this.getArticle(this.articleId);
        }
    }

    savePicture(event) {
        this.article.picture = event as string;
    }

    saveContent(event) {
        this.article.content = event as string;
    }

    getarticles() {
        this.topicTableService.getTopics()
            .subscribe((topics: Topic[]) => this.topics = topics);
    }

    getArticle(articleId: number) {
        this.articleDialogService.getArticle(articleId)
            .subscribe((article: Article) => this.article = article);
    }

    createArticle() {
        return this.articleDialogService.createArticle(this.article).subscribe(res => {
            this.dialogRef.close();          
        });
    }

    updateArticle() {
        return this.articleDialogService.updateArticle(this.article).subscribe(res => {
            this.dialogRef.close();
        });
    }

    submitArticle() {
        this.isAddMode
            ? this.createArticle().add(() => this.openSnackBark('Your Article has been created.', 'Complete'))
            : this.updateArticle().add(() => this.openSnackBark('Your Article been modified.', 'Complete'))
    }

    openSnackBark(notificationMessage: string, actionMessage: string)
    {
        this.snackBar.open(notificationMessage, actionMessage, {
            duration: 2000
        });
    }

    closeDialog() {
        this.dialogRef.close();
    }
}
