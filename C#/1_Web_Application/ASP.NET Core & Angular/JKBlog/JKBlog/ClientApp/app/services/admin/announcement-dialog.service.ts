import { Injectable } from '@angular/core';
import { Announcement } from '../../models/dataModel/announcement';
import { User } from '../../models/dataModel/user';
import { UserService } from '../user.service';
import { JWTGatewayService } from '../jwtgateway.service';

@Injectable()
export class AnnouncementDialogService {

    constructor(private userService: UserService,
        private jwtGateway: JWTGatewayService) {

    }

    getAnnouncement(announcementId: number) {
        return this.jwtGateway.get(`api/Admin/Announcement/${announcementId}`);
    }

    createAnnouncement(announcement: Announcement) {
        //const userId = Number(localStorage.getItem('userId'));
        const user = this.userService.getUser as User// Get user from session
        announcement.userId = user.userId

        return this.jwtGateway.post('api/Admin/Announcement/Create', announcement);
    }

    updateAnnouncement(announcement: Announcement) {
        return this.jwtGateway.put(`api/Admin/Announcement/Update/${announcement.announcementId}`, announcement);
    }

    deleteAnnouncement(announcementId: number) {
        return this.jwtGateway.delete(`api/Admin/Announcement/Delete/${announcementId}`);
    }
}
