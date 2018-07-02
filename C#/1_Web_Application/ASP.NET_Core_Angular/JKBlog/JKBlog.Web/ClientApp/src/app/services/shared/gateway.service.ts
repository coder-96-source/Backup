import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class GatewayService {
  const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    protected http: HttpClient,
    protected router: Router) {

    }

    get(url: string) : Observable<any> {
      return this.http.get(`${url}`)
        .pipe(
          map(res => res),
          tap(heroes => console.log(),
        catchError(this.handleError('getHeroes', [])
        );
    }

    post(url: string, data: any) {
        return this.http.post(`${this.baseUrl}${url}`, data).pipe(map(res => res));
    }

    put(url: string, data: any) {
        return this.http.put(`${this.baseUrl}${url}`, data).pipe(map(res => res));
    }

    delete(url: string) {
        return this.http.delete(`${this.baseUrl}${url}`).pipe(map(res => res));
    }

    navigateHome() {
        this.router.navigate([this.baseUrl]);
    }

  /**
 * Handle Http operation that failed.
 * Let the app continue.
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
