import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';

import { UserService } from '../../services/user.service';

@Component({
    selector: 'app-nav',
    templateUrl: './nav.component.html',
    styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit, OnDestroy {

    status: boolean;
    subscription: Subscription;

    constructor(private userService: UserService) {
    }

    logout() {
        this.userService.logout();
    }

    ngOnInit() {
        this.subscription = this.userService.authNavStatus$.subscribe(status => this.status = status);
    }

    ngOnDestroy() {
        // prevent memory leak when component is destroyed
        this.subscription.unsubscribe();
    }
}
