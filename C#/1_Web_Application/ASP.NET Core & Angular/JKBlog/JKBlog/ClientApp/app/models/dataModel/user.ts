import { Article } from './article';
import { Announcement } from './announcement';

export class User {
    userId: number;
    name: string;
    password: string;
    birthdate: Date;
    picture: number;
    pictureMimeType: string;

    //permissionId: number;
    //permission: Permission;

    articles: Article[];

    announcements: Announcement[];
}