import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

import { Observable, of, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { SnackbarService, SnackbarAction } from './snackbar.service';

@Injectable({ providedIn: 'root' })
export class GatewayService {

  constructor(
    protected http: HttpClient,
    protected router: Router,
    protected snackbarService: SnackbarService) {

  }

  get(url: string): Observable<any> {
    return this.http.get(`${url}`)
      .pipe(
        map(res => res),
        tap(data => this.writeInfoLog(url)),
      catchError(error => {
        this.handleError(error);
        return throwError(error);
      }));
  }

  post(url: string, data: any): Observable<any> {
    return this.http.post(`${url}`, data)
      .pipe(
        map(res => res),
        tap(data => this.writeInfoLog(url)),
        catchError(error => {
          this.handleError(error);
          return throwError(error);
        }));
  }

  put(url: string, data: any): Observable<any> {
    return this.http.put(`${url}`, data)
      .pipe(
        map(res => res),
        tap(data => this.writeInfoLog(url)),
        catchError(error => {
          this.handleError(error);
          return throwError(error);
        }));
  }

  delete(url: string): Observable<any> {
    return this.http.delete(`${url}`)
      .pipe(
        map(res => res),
        tap(data => this.writeInfoLog(url)),
        catchError(error => {
          this.handleError(error);
          return throwError(error);
        }));
  }

  navigateHome() {
    this.router.navigateByUrl('');
  }

  writeErrorLog(message: string) {
    this.http.post('api/logs/error', message);
  }

  writeInfoLog(message: string) {
    this.http.post('api/logs/info', message);
  }

  protected handleError<T>(error: any) {
    const httpResponse = error as HttpErrorResponse;
    this.writeErrorLog(error); // System side logging
    this.snackbarService.openSnackBar(httpResponse.error, SnackbarAction.Error); // Client side display
  }
}
