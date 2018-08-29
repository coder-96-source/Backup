import { Injectable } from '@angular/core';
import { Announcement } from '../../../models/announcement';
import { GatewayService } from '../../../services/shared/gateway.service';

@Injectable()
export class AnnouncementService {

    constructor(private gateway: GatewayService) {

    }

    getAnnouncements() {
        return this.gateway.get('api/announcements');
    }
}
