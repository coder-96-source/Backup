import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { User } from '../../../models/dataModel/user';
import { UserService } from '../../../services/user.service';

@Component({
    selector: 'app-registration',
    templateUrl: './registration.component.html',
    styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
    errors: string;
    user: User;

    constructor(private userService: UserService, private router: Router) {

    }

    ngOnInit() {

    }

    registerUser({ value, valid }: { value: User, valid: boolean }) {
        if (valid) {
            this.userService.register(value.name, value.password, value.birthdate)
                .subscribe(result => {
                    if (result) {
                        this.router.navigate(['/app/home']);
                    }
                },
                errors => this.errors = errors);
        }
    }
}