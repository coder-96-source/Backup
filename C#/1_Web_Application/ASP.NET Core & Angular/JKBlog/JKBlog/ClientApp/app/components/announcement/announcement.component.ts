import { Component, OnInit, Inject } from '@angular/core';
import { Announcement } from '../../models/dataModel/announcement';
import { AnnouncementService } from '../../services/announcement.service';

@Component({
    selector: 'app-announcement',
    templateUrl: './announcement.component.html',
    styleUrls: ['./announcement.component.css']
})

export class AnnouncementComponent implements OnInit {
    title = 'Announcement'
    announcements: Announcement[];
    errorMessage: string;

    constructor(private announcementService: AnnouncementService) {

    }

    ngOnInit() {
        this.fetchAnnouncements().subscribe(res => {
            this.announcements = res as Announcement[];
        }, error => this.errorMessage = error as string);
    }

    fetchAnnouncements() {
        return this.announcementService.getAnnouncements();
    }
}
