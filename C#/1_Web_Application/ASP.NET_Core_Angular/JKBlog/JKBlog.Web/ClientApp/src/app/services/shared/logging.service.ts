import { Injectable } from '@angular/core';

import { GatewayService } from './gateway.service';

@Injectable()
export class LoggingService {

  constructor(
    private gatewayService: GatewayService) {

  }

  writeErrorLog(message: string) {
    this.gatewayService.post('api/logs/error', message);
  }

  writeInfoLog(message: string) {
    this.gatewayService.post('api/logs/info', message);
  }
}
