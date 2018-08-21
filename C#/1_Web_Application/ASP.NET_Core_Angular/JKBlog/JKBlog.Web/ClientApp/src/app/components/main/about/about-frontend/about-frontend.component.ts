import { Component, OnInit } from '@angular/core';
import { Feature } from '../../../../models/feature'
import { AboutService } from '../../../../services/main/about/about.service';
import { LoggingService } from '../../../../services/shared/logging.service';
import { SnackbarService, SnackbarAction } from '../../../../services/shared/snackbar.service';

@Component({
  selector: 'app-about-frontend',
  templateUrl: './about-frontend.component.html',
  styleUrls: ['./about-frontend.component.scss']
})
export class AboutFrontendComponent implements OnInit {
  private isLoaded = false;
  private features: Feature[];

  constructor(
    private aboutService: AboutService,
    private loggingService: LoggingService,
    private snackbarService: SnackbarService) {

  }

  ngOnInit() {
    this.initializeArticles();
  }

  fetchFeatures() {
    return this.aboutService.getFrontendFeatures();
  }

  initializeArticles() {
    this.fetchFeatures().subscribe(res => {
      this.features = res as Feature[];
      this.isLoaded = true;
    },
      error => {
        const errorMessage = error as string;
        this.loggingService.writeErrorLog(errorMessage);
        this.snackbarService.openSnackBar(errorMessage, SnackbarAction.Error);
      });
  }
}
