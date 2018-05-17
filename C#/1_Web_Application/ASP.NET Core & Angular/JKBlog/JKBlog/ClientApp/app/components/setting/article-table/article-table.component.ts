import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatPaginator, MatSort, MatTableDataSource, MatSnackBar } from '@angular/material';
import { Observable } from 'rxjs/Observable';
import { Article } from '../../../models/dataModel/article';
import { ArticleTableService } from '../../../services/admin/article-table.service';
import { ArticleDialogComponent } from './article-dialog/article-dialog.component';
import { ArticleDialogService } from '../../../services/admin/article-dialog.service';

@Component({
    selector: 'app-admin-article-table',
    templateUrl: './article-table.component.html',
    styleUrls: ['./article-table.component.css']
})

export class ArticleTableComponent {
    private displayedColumns = ['articleId', 'postDate', 'showFlag', 'picture',
        'title', 'contentDisplay', 'action'];
    private dataSource: MatTableDataSource<Article>;

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    constructor(
        private articleTableService: ArticleTableService,
        private articleDialogService: ArticleDialogService,
        private dialog: MatDialog,
        private snackBar: MatSnackBar) {
    }

    ngOnInit() {
        this.fetchAllArticles().subscribe(res => {
            this.dataSource = new MatTableDataSource<Article>(res as Article[]);
            this.dataSource.paginator = this.paginator;
            this.dataSource.sort = this.sort;
        });
    }

    fetchAllArticles() {
        return this.articleTableService.getArticles();
    }

    applyFilter(filterValue: string) {
        filterValue = filterValue.trim(); // Remove whitespace
        filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
        this.dataSource.filter = filterValue;
    }

    createArticle() {
        const dialogRef = this.dialog.open(ArticleDialogComponent, {
            height: '70%', width: '50%'
        });
        dialogRef.componentInstance.isAddMode = true;
        dialogRef.afterClosed()
            .switchMap(() => { return this.fetchAllArticles(); })
            .subscribe(res => { this.dataSource = res; });
    }

    editArticle(id: number) {
        const dialogRef = this.dialog.open(ArticleDialogComponent, {
            height: '70%', width: '50%'
        });
        dialogRef.componentInstance.isAddMode = false;
        dialogRef.componentInstance.articleId = id;
        dialogRef.afterClosed()
            .switchMap(() => this.fetchAllArticles())
            .subscribe(res => this.dataSource = res);
    }

    deleteArticle(id: number) {
        this.articleDialogService.deleteArticle(id)
            .switchMap(() => this.fetchAllArticles())
            .subscribe(res => {
                this.dataSource = res;
                this.snackBar.open('Your article has been deleted.', 'Complete', {
                    duration: 2000
                });
            });
    }
}