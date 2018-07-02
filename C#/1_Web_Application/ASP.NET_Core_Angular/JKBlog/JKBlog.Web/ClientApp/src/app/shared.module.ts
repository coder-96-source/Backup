import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';

import { GatewayService } from './services/shared/gateway.service';
import { JWTGatewayService } from './services/shared/jwtgateway.service';

@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule,
    HttpModule,
    HttpClientModule
  ],
  providers: [
    GatewayService,
    JWTGatewayService
  ],
  bootstrap: [

  ]
})
export class SharedModule { }
