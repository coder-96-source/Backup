import { Component, OnInit } from '@angular/core';
import { Feature } from '../../../../models/feature'
import { AboutService } from '../../../../services/main/about/about.service';

@Component({
    selector: 'app-about-frontend',
    templateUrl: './about-frontend.component.html',
    styleUrls: ['./about-frontend.component.scss']
})
export class AboutFrontendComponent implements OnInit {
    private isLoaded = false;
    private features?: Feature[];

    constructor(private aboutService: AboutService) {

    }

    ngOnInit() {
        this.fetchArticles().subscribe(res => {
            this.features = res as Feature[];
            this.isLoaded = true;
        });
    }

    fetchArticles() {
        return this.aboutService.getFrontendFeatures();
    }
}
