import { Component, OnInit } from '@angular/core';
import { Feature } from '../../../../models/feature'
import { AboutService } from '../../../../services/main/about/about.service';

@Component({
    selector: 'app-about-backend',
    templateUrl: './about-backend.component.html',
    styleUrls: ['./about-backend.component.scss']
})
export class AboutBackendComponent implements OnInit {
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
        return this.aboutService.getBackendFeatures();
    }
}
