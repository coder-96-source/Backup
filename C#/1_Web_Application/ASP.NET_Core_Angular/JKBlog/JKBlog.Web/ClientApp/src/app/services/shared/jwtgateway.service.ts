import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { SnackbarService, SnackbarAction } from './snackbar.service';
import { LoggingService } from './logging.service';
import { GatewayService } from './gateway.service';
import { UserService } from '../user/user.service';


@Injectable({ providedIn: 'root' })
export class JWTGatewayService extends GatewayService {
  private headers: HttpHeaders;
  private httpOptions?: any;

  constructor(
    protected http: HttpClient,
    protected router: Router,
    protected loggingService: LoggingService,
    protected snackbarService: SnackbarService,
    private userService: UserService) {
    super(http, router, loggingService, snackbarService);
    this.makeDefaultHttpOption();
  }

  makeDefaultHttpOption() {
    const jwtToken = this.userService.getJwtToken;
    this.httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${jwtToken}`
      })
    };
  }

  get(url: string): Observable<any> {
    return this.http.get(`${url}`, this.httpOptions)
      .pipe(map(res => res));
  }

  post(url: string, data: any): Observable<any> {
    return this.http.post(`${url}`, data, this.httpOptions).pipe(map(res => res));
  }

  put(url: string, data: any): Observable<any> {
    return this.http.put(`${url}`, data, this.httpOptions).pipe(map(res => res));
  }

  delete(url: string): Observable<any> {
    return this.http.delete(`${url}`, this.httpOptions).pipe(map(res => res));
  }
}
