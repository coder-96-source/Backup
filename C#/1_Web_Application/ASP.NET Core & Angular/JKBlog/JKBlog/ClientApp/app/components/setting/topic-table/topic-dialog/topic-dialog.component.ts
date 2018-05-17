import { Component, Input, OnInit, NgModule } from '@angular/core';
import { MatDialogRef, MatSnackBar } from '@angular/material';
import { Topic } from '../../../../models/dataModel/topic';
import { TopicDialogService } from '../../../../services/admin/topic-dialog.service';
import { PictureUploaderComponent } from '../../picture-uploader/picture-uploader.component';

@Component({
    selector: 'app-admin-topic-dialog',
    templateUrl: './topic-dialog.component.html',
    //styleUrls: ['./topic-dialog.component.css']
})

export class TopicDialogComponent implements OnInit {
    public isAddMode: boolean;
    public topicId: number;
    private topic: Topic;

    constructor(
        private topicDialogService: TopicDialogService,
        private dialogRef: MatDialogRef<TopicDialogComponent>,
        private snackBar: MatSnackBar
    ) { }

    ngOnInit() {
        this.topic = new Topic(); // to avoid null reference
        if (!this.isAddMode) { // Edit mode
            this.getTopic(this.topicId);
        }
    }

    savePicture(event) {
        this.topic.picture = event as string;
    }

    getTopic(topicId: number) {
        this.topicDialogService.getTopic(topicId)
            .subscribe((topic: Topic) => this.topic = topic);
    }

    submitTopic() {
        this.isAddMode
            ? this.createTopic().add(() => this.openSnackBark('Your topic has been created.', 'Complete'))
            : this.updateTopic().add(() => this.openSnackBark('Your topic been modified.', 'Complete'))
    }

    createTopic() {
        return this.topicDialogService.createTopic(this.topic).subscribe(res => {
            this.dialogRef.close();          
        });
    }

    updateTopic() {
        return this.topicDialogService.updateTopic(this.topic).subscribe(res => {
            this.dialogRef.close();
        });
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
