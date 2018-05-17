import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatPaginator, MatSort, MatTableDataSource, MatSnackBar } from '@angular/material';
import { Observable } from 'rxjs/Observable';
import { TopicDialogComponent } from './topic-dialog/topic-dialog.component';
import { Topic } from '../../../models/dataModel/topic';
import { TopicTableService } from '../../../services/admin/topic-table.service';
import { TopicDialogService } from '../../../services/admin/topic-dialog.service';

@Component({
    selector: 'app-admin-topic-table',
    templateUrl: './topic-table.component.html',
    //styleUrls: ['./topic-table.component.css']
})

export class TopicTableComponent implements OnInit {
    private displayedColumns = ['topicId', 'postDate', 'showFlag', 'picture',
        'title', 'description', 'action'];
    private dataSource: MatTableDataSource<Topic>;

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    constructor(
        private topicTableService: TopicTableService,
        private topicDialogService: TopicDialogService,
        private dialog: MatDialog,
        private snackBar: MatSnackBar) {
    }

    ngOnInit() {
        this.fetchAllTopics().subscribe(res => {
            this.dataSource = new MatTableDataSource<Topic>(res as Topic[]);
            this.dataSource.paginator = this.paginator;
            this.dataSource.sort = this.sort;
        });
    }

    fetchAllTopics() {
        return this.topicTableService.getTopics();      
    }

    applyFilter(filterValue: string) {
        filterValue = filterValue.trim(); // Remove whitespace
        filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
        this.dataSource.filter = filterValue;
    }

    createTopic() {
        const dialogRef = this.dialog.open(TopicDialogComponent, {
            height: '590px', width: '430px'
        });
        dialogRef.componentInstance.isAddMode = true;
        dialogRef.afterClosed()
            .switchMap(() => { return this.fetchAllTopics(); })
            .subscribe(res => { this.dataSource = res; });
    }

    editTopic(id: number) {       
        const dialogRef = this.dialog.open(TopicDialogComponent, {
            height: '590px', width: '430px'
        });
        dialogRef.componentInstance.isAddMode = false;
        dialogRef.componentInstance.topicId = id;
        dialogRef.afterClosed()
            .switchMap(() => this.fetchAllTopics())
            .subscribe(res => this.dataSource = res);
    }

    deleteTopic(id: number) {
        this.topicDialogService.deleteTopic(id)
            .switchMap(() => this.fetchAllTopics())
            .subscribe(res => {
                this.dataSource = res;
                this.snackBar.open('Your topic has been deleted.', 'Complete', {
                    duration: 2000
                });
            });
    }
}

//import { Component, OnInit } from '@angular/core';

//import { Topic } from '../../../models/dataModel/topic';
//import { TopicService } from '../../../services/topic.service';

//@Component({
//    selector: 'app-topic-form',
//    templateUrl: './topic-form.component.html',
//    styleUrls: ['./topic-form.component.css']
//})

//export class TopicFormComponent {
//    errors: string;
//    article: Topic;

//    errorMessage: string;
//    topic: Topic;

//    constructor(private topicService: TopicService) {

//    }

//    createTopic() {

//    }

//    //addArticle({ value, valid }: { value: Topic, valid: boolean }) {
//    //    if (valid) {
//    //        article.topicId = this.selectedTopicId; // topic binding
//    //        this.articleListService.addArticle
//    //    }
//    //}

//    //createTopic({ value, valid }: { value: Topic, valid: boolean }) {
//    //    if (valid) {
//    //        this.topicService.createTopic(value.title, value.category, value.description, value.postDate, value.showFlag)
//    //            .subscribe(result => {
//    //                if (result) {
//    //                    this.router.navigate(['/app/home']);
//    //                }
//    //            },
//    //            errors => this.errors = errors);
//    //    }
//    //}
//}
