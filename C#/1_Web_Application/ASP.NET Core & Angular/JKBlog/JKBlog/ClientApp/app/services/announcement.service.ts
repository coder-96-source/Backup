import { Injectable } from '@angular/core';
import { Announcement } from '../models/dataModel/announcement';
import { GatewayService } from './gateway.service';

@Injectable()
export class AnnouncementService {

    constructor(private gateway: GatewayService) {

    }

    getAnnouncements() {
        return this.gateway.get('api/Home/Announcements');
    }
}
