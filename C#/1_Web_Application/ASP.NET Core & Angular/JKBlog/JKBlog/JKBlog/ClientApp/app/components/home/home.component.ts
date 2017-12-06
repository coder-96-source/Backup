import { Component } from '@angular/core';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})

export class HomeComponent {
    images: any;

    constructor() {
        this.images = [
            {
                'url': 'https://www.w3schools.com/w3images/lights.jpg',
                'title': 'Aliquam erat volutpat',
                'caption': '1'
            },
            {
                'url': 'https://www.w3schools.com/w3images/lights.jpg',
                'title': 'Aliquam erat volutpat',
                'caption': '2'
            },
            {
                'url': 'https://www.w3schools.com/w3images/lights.jpg',
                'title': 'Aliquam erat volutpat',
                'caption': '3'
            },
            {
                'url': 'https://www.w3schools.com/w3images/lights.jpg',
                'title': 'Aliquam erat volutpat',
                'caption': '4'
            },
            {
                'url': 'https://www.w3schools.com/w3images/lights.jpg',
                'title': 'Aliquam erat volutpat',
                'caption': '5'
            },
            {
                'url': 'https://www.w3schools.com/w3images/lights.jpg',
                'title': 'Aliquam erat volutpat',
                'caption': '6'
            }
        ];
    }
}
