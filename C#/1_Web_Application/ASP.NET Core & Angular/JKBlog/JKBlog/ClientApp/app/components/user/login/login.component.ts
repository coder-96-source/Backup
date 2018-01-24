import { Subscription } from 'rxjs';
import { Component, OnInit,OnDestroy } from '@angular/core';
import { Router } from '@angular/router';

import { User } from '../../../models/dataModel/user';
import { UserService } from '../../../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit, OnDestroy {
    private subscription: Subscription;

    errors: string;

    constructor(private userService: UserService, private router: Router) {

    }

    ngOnInit() {

    }

    ngOnDestroy() {
        // prevent memory leak by unsubscribing
        this.subscription.unsubscribe();
    }

    login({ value, valid }: { value: User, valid: boolean }) {
        if (valid) {
            this.userService.login(value.name, value.password)
                .subscribe(result => {
                    if (result) {
                        this.router.navigate(['/app/home']);
                    }
                },
                error => this.errors = error);
        }
    }
}
