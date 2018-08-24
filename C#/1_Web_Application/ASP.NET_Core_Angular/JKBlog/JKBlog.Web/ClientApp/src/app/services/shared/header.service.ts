import { Component, OnDestroy, Injectable } from '@angular/core';
import { Observable, BehaviorSubject, Subscription} from 'rxjs';
import { MediaChange, ObservableMedia } from '@angular/flex-layout';

@Injectable()
export class HeaderService implements OnDestroy {
  private watcher: Subscription;
  private activeMediaQuery: string;
  private activeSize: string;
  private isSidenavOpened$ = new BehaviorSubject<boolean>(false); // Default closed
  private isMobile$ = new BehaviorSubject<boolean>(false);
  private menuItems: any[] = [];

  constructor(private media: ObservableMedia) {
    this.watcher = this.media.subscribe((change: MediaChange) => {
      this.activeMediaQuery = change ? `'${change.mqAlias}' = (${change.mediaQuery})` : '';
      this.activeSize = change.mqAlias; // 'xs', 'sm', ..., 'xl'
      this.isMobile$.next(this.activeSize == 'xs');
      this.isSidenavOpened$.next(false); // Close when media query detected
    });
    this.setMenuItems();
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
}
