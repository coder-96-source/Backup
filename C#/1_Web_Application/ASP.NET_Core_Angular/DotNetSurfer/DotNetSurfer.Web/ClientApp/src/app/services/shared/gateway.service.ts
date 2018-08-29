import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { LoggingService } from './logging.service';
import { SnackbarService, SnackbarAction } from './snackbar.service';

@Injectable({ providedIn: 'root' })
export class GatewayService {

  constructor(
    protected http: HttpClient,
    protected router: Router,
    protected loggingService: LoggingService,
    protected snackbarService: SnackbarService) {

  }

  get(url: string): Observable<any> {
    return this.http.get(`${url}`)
      .pipe(
        map(res => res),
        tap(data => this.loggingService.writeInfoLog(url)),
        catchError(this.handleError(url, []))
      );
  }

  post(url: string, data: any): Observable<any> {
    return this.http.post(`${url}`, data).pipe(
      map(res => res),
      tap(data => this.loggingService.writeInfoLog(url)),
      catchError(this.handleError(url, []))
    );
  }

  put(url: string, data: any): Observable<any> {
    return this.http.put(`${url}`, data).pipe(
      map(res => res),
      tap(data => this.loggingService.writeInfoLog(url)),
      catchError(this.handleError(url, []))
    );
  }

  delete(url: string): Observable<any> {
    return this.http.delete(`${url}`).pipe(
      map(res => res),
      tap(data => this.loggingService.writeInfoLog(url)),
      catchError(this.handleError(url, []))
    );
  }

  navigateHome() {
    // this.router.initialNavigation();
  }

  protected handleError<T>(url: string, result?: T) {
    return (error: any): Observable<T> => {
      this.loggingService.writeErrorLog(error); // System side logging
      this.snackbarService.openSnackBar('Error occurred. Please contact administrator.', SnackbarAction.Error); // Client side display

      // Let the app keep running by returning an empty result.
      return of(result as T); // optional value to return as the observable result
    };
  }
}
