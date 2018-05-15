import { Injectable } from '@angular/core';
import { Announcement } from '../../models/dataModel/announcement';
import { JWTGatewayService } from '../jwtgateway.service';

@Injectable()
export class AnnouncementTableService {

    constructor(public jwtGateway: JWTGatewayService) {

    }

    getAnnouncements() {
        return this.jwtGateway.get('api/Admin/Announcements');
    }
}
