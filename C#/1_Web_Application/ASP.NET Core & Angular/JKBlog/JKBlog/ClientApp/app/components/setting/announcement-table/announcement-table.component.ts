import { Component, OnInit, ViewChild  } from '@angular/core';
import { MatDialog, MatPaginator, MatSort, MatTableDataSource, MatSnackBar } from '@angular/material';
import { Observable } from 'rxjs/Observable';
import { AnnouncementDialogComponent } from './announcement-dialog/announcement-dialog.component';
import { Announcement } from '../../../models/dataModel/announcement';
import { AnnouncementTableService } from '../../../services/admin/announcement-table.service';
import { AnnouncementDialogService } from '../../../services/admin/announcement-dialog.service';

@Component({
    selector: 'app-admin-announcement-table',
    templateUrl: './announcement-table.component.html',
    //styleUrls: ['./announcement-table.component.css']
})

export class AnnouncementTableComponent implements OnInit {
    private displayedColumns = ['announcementId', 'postDate', 'showFlag', 'content', 'action'];
    private dataSource: MatTableDataSource<Announcement>;

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    constructor(
        private announcementTableService: AnnouncementTableService,
        private announcementDialogService: AnnouncementDialogService,
        private dialog: MatDialog,
        private snackBar: MatSnackBar) {
    }

    ngOnInit() {
        this.fetchAllAnnouncements().subscribe(res => {
            this.dataSource = new MatTableDataSource<Announcement>(res as Announcement[]);
            this.dataSource.paginator = this.paginator;
            this.dataSource.sort = this.sort;
        });
    }

    fetchAllAnnouncements() {
        return this.announcementTableService.getAnnouncements();      
    }

    applyFilter(filterValue: string) {
        filterValue = filterValue.trim(); // Remove whitespace
        filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
        this.dataSource.filter = filterValue;
    }

    createAnnouncement() {
        const dialogRef = this.dialog.open(AnnouncementDialogComponent, {
            height: '300px', width: '350px'
        });
        dialogRef.componentInstance.isAddMode = true;
        dialogRef.afterClosed()
            .switchMap(() => { return this.fetchAllAnnouncements(); })
            .subscribe(res => { this.dataSource = res; });
    }

    editAnnouncement(id: number) {       
        const dialogRef = this.dialog.open(AnnouncementDialogComponent, {
            height: '300px', width: '350px'
        });
        dialogRef.componentInstance.isAddMode = false;
        dialogRef.componentInstance.announcementId = id;
        dialogRef.afterClosed()
            .switchMap(() => this.fetchAllAnnouncements())
            .subscribe(res => this.dataSource = res);
    }

    deleteAnnouncement(id: number) {
        this.announcementDialogService.deleteAnnouncement(id)
            .switchMap(() => this.fetchAllAnnouncements())
            .subscribe(res => {
                this.dataSource = res;
                this.snackBar.open('Your announcement has been deleted.', 'Complete', {
                    duration: 2000
                });
            });
    }
}