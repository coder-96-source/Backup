import { User } from './user';

export class Permission {
    permissionId: number;
    PermissionType: string;

    users: User[];
}