import { User } from './user';

export class Announcement {
    announcementId: number;
    content: string;
    postDate: Date;
    modifyDate: Date;
    showFlag: boolean;

    userId: number;
    user: User;
}