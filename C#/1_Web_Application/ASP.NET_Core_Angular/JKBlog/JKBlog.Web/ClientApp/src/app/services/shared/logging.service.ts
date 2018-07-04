import { Injectable } from '@angular/core';

import { GatewayService } from './gateway.service';

@Injectable()
export class LoggingService {

  constructor(
    private gatewayService: GatewayService) {

  }

  writeErrorLog(url: string, data = undefined) {
    this.gatewayService.post('api/logs/error', data)
  }

  writeInfoLog(url: string, data = undefined) {
    this.gatewayService.post('api/logs/info', data)
  }
}
