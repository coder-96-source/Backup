import { Component, Input, OnInit } from '@angular/core';
import { MatDialogRef, MatSnackBar, MatCheckboxModule } from '@angular/material';
import { Announcement } from '../../../../models/dataModel/announcement';
import { AnnouncementDialogService } from '../../../../services/admin/announcement-dialog.service';

@Component({
    selector: 'app-admin-announcement-dialog',
    templateUrl: './announcement-dialog.component.html',
    //styleUrls: ['./announcement-dialog.component.css']
})

export class AnnouncementDialogComponent implements OnInit {
    public isAddMode: boolean;
    public announcementId: number;
    private announcement: Announcement = new Announcement();

    constructor(
        private announcementDialogService: AnnouncementDialogService,
        private dialogRef: MatDialogRef<AnnouncementDialogComponent>,
        private snackBar: MatSnackBar
    ) { }

    ngOnInit() {
        if (!this.isAddMode) { // Edit mode
            this.getAnnouncement(this.announcementId);
        }
    }

    getAnnouncement(announcementId: number) {
        this.announcementDialogService.getAnnouncement(announcementId)
            .subscribe((announcement: Announcement) => this.announcement = announcement);
    }

    submitAnnouncement() {
        this.isAddMode
            ? this.createAnnouncement().add(() => this.openSnackBark('Your announcement has been created.', 'Complete'))
            : this.updateAnnouncement().add(() => this.openSnackBark('Your announcement been modified.', 'Complete'))
    }

    createAnnouncement() {
        return this.announcementDialogService.createAnnouncement(this.announcement).subscribe(res => {
            this.dialogRef.close();
        });
    }

    updateAnnouncement() {
        return this.announcementDialogService.updateAnnouncement(this.announcement).subscribe(res => {
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
