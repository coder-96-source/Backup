import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Announcement } from '../../models/dataModel/announcement';

@Component({
    selector: 'app-announcement',
    templateUrl: './announcement.component.html',
    styleUrls: ['./announcement.component.css']
})

export class AnnouncementComponent {
    title = 'Announcement'
    announcements: Announcement[];

    constructor(private http: Http) {

    }

    ngOnInit() {
        this.http.get('api/Home/GetAnnouncements').subscribe(a => {
            this.announcements = a.json();
        });
    }
}
