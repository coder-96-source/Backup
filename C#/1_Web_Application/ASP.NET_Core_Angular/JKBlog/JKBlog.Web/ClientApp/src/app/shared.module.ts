import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import {
  MatToolbarModule,
  MatSidenavModule,
  MatListModule,
  MatButtonModule,
  MatSnackBarModule,
  MatIconModule
} from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { PipeSharedModule } from './pipes/pipe.shared.module';

import { TopNavComponent } from './components/shared/topnav/topnav.component';
import { FooterComponent } from './components/shared/footer/footer.component';

import { GatewayService } from './services/shared/gateway.service';
import { JWTGatewayService } from './services/shared/jwtgateway.service';
import { SnackbarService } from './services/shared/snackbar.service';
import { LoggingService } from './services/shared/logging.service';

@NgModule({
  declarations: [
    TopNavComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    HttpClientModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatButtonModule,  
    MatSnackBarModule,
    MatIconModule,
    FlexLayoutModule,
    PipeSharedModule
  ],
  exports: [
    TopNavComponent,
    FooterComponent,
    PipeSharedModule
  ],
  providers: [
    GatewayService,
    JWTGatewayService,
    SnackbarService,
    LoggingService
  ],
  bootstrap: [

  ]
})
export class SharedModule { }
