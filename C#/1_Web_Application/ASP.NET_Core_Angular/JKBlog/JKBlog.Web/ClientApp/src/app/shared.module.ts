import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { GatewayService } from './services/shared/gateway.service';
import { JWTGatewayService } from './services/shared/jwtgateway.service';
import { SnackbarService } from './services/shared/snackbar.service';
import { LoggingService } from './services/shared/logging.service';

@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule,
    HttpClientModule
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
