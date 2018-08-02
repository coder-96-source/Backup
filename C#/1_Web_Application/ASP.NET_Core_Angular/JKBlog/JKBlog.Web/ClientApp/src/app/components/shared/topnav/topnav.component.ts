//import { Component, Input } from '@angular/core';
//import { SideNavComponent } from '../sidenav/sidenav.component'
//import { UserService } from '../../../services/user/user.service';
import {MediaMatcher} from '@angular/cdk/layout';
import {ChangeDetectorRef, Component, OnDestroy} from '@angular/core';


@Component({
  selector: 'app-topnav',
  templateUrl: './topnav.component.html',
  styleUrls: ['./topnav.component.scss']
})
export class TopNavComponent implements OnDestroy {
  private mobileQuery: MediaQueryList;

  private _mobileQueryListener: () => void;

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
  }

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }
  //constructor(private userService: UserService) {
  //}

  //logout() {
  //  this.userService.signOut();
  //}

  //signOut() {
  //  this.userService.signOut();
  //}
}
