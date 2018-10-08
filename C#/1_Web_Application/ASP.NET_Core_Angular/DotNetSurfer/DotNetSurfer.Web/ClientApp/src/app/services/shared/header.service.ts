import { OnDestroy, Injectable } from '@angular/core';
import { Observable, BehaviorSubject, Subscription } from 'rxjs';
import { MediaChange, ObservableMedia } from '@angular/flex-layout';
import { UserService } from '../admin/user/user.service';

@Injectable()
export class HeaderService implements OnDestroy {
  private watcher: Subscription;
  private activeMediaQuery: string;
  private activeSize: string;
  private isSidenavOpened$ = new BehaviorSubject<boolean>(false); // Default closed
  private isMobile$ = new BehaviorSubject<boolean>(false);
  private menuItems: any[] = [];
  private adminMenuItems: any[] = [];

  constructor(
    private media: ObservableMedia,
    private userSerivce: UserService) {
    this.watcher = this.media.subscribe((change: MediaChange) => {
      this.activeMediaQuery = change ? `'${change.mqAlias}' = (${change.mediaQuery})` : '';
      this.activeSize = change.mqAlias; // 'xs', 'sm', ..., 'xl'
      this.isMobile$.next(this.activeSize == 'xs');
      this.isSidenavOpened$.next(false); // Close when media query detected
    });
    this.setMenuItems();
    this.setAdminMenuItems();
  }

  ngOnDestroy() {
    this.watcher.unsubscribe();
  }

  getIsSidenavOpened(): Observable<boolean> {
    return this.isSidenavOpened$.asObservable();
  }

  setIsSidenavOpened(isSidenavOpened: boolean) {
    this.isSidenavOpened$.next(isSidenavOpened);
  }

  getIsMobile(): Observable<boolean> {
    return this.isMobile$.asObservable();
  }

  setIsMobile(isMobile: boolean) {
    this.isMobile$.next(isMobile);
  }

  getMenuItems() {
    return this.menuItems;
  }

  getAdminMenuItems() {
    return this.adminMenuItems;
  }

  getIsAuthenticated() {
    return this.userSerivce.getIsAuthenticated;
  }

  signOut() {
    this.userSerivce.signOut();
  }

  private setMenuItems() {
    this.menuItems.push({
      name: 'Home',
      icon: 'home',
      routerLink: '/home'
    });
    this.menuItems.push({
      name: 'About',
      icon: 'info',
      routerLink: '/about'
    });
    this.menuItems.push({
      name: 'Contact',
      icon: 'contacts',
      routerLink: '/contact'
    });
  }

  private setAdminMenuItems() {
    this.adminMenuItems.push({
      name: 'Profile',
      icon: 'person',
      routerLink: '/admin/profile'
    });
    this.adminMenuItems.push({
      name: 'Topic',
      icon: 'library_books',
      routerLink: '/admin/topic'
    });
    this.adminMenuItems.push({
      name: 'Article',
      icon: 'rate_review',
      routerLink: '/admin/article'
    });
    this.adminMenuItems.push({
      name: 'Announcement',
      icon: 'list_alt',
      routerLink: '/admin/announcement'
    });
  }
}
