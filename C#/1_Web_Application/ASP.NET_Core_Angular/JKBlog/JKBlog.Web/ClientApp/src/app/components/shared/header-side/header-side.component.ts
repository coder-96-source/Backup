import { Component, OnInit } from '@angular/core';
import { HeaderService } from '../../../services/shared/header.service';

@Component({
  selector: 'app-header-side',
  templateUrl: './header-side.component.html',
  styleUrls: ['./header-side.component.scss']
})
export class HeaderSideComponent implements OnInit {
  private isOpen: boolean;
  private menuItems: any[] = [];

  constructor(private headerService: HeaderService) {

  }

  ngOnInit() {
    this.headerService.getIsSidenavOpened().subscribe(s => { 
      this.isOpen = s as boolean;
    });
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
