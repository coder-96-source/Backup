import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { MainModule } from './components/main/main.module';
import { SharedModule } from './shared.module';

import { AppRoutingModule } from './app.routing';

import { AppComponent } from './app.component';

import { GatewayService } from './services/shared/gateway.service';
import { JWTGatewayService } from './services/shared/jwtgateway.service';
import { SnackbarService } from './services/shared/snackbar.service';
import { LoggingService } from './services/shared/logging.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    //MainModule,
    SharedModule,

    AppRoutingModule
  ],
  providers: [
    GatewayService,
    JWTGatewayService,
    SnackbarService,
    LoggingService
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
