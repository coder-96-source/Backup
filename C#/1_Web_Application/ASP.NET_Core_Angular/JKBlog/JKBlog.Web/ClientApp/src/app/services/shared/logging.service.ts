import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class LoggingService {

  constructor(
    private http: HttpClient) {

  }

  writeErrorLog(message: string) {
    this.http.post('api/logs/error', message);
  }

  writeInfoLog(message: string) {
    this.http.post('api/logs/info', message);
  }
}
