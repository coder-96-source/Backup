import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { GatewayService } from './gateway.service';
import { UserService } from '../user/user.service';
import { ResponseType } from '@angular/http';

@Injectable()
export class JWTGatewayService extends GatewayService {
    private headers?: HttpHeaders;
    private httpOptions?: any;

    constructor(protected http: HttpClient,
        @Inject('BASE_URL') protected baseUrl: string,
        protected router: Router,
        private userService: UserService) {
        super(http, baseUrl, router);
        this.makeDefaultHttpOption();
    }

    makeDefaultHttpOption() {
        const jwtToken = this.userService.getJwtToken;
        this.httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${jwtToken}`
            }),
            responseType: 'json'
        };
    }

    get(url: string): Observable<any> {
        return this.http.get(`${this.baseUrl}${url}`, this.httpOptions)
            .pipe(map(res => res));
    }

    post(url: string, data: any): Observable<any> {
        return this.http.post(`${this.baseUrl}${url}`, data, this.httpOptions).pipe(map(res => res));
    }

    put(url: string, data: any): Observable<any> {
        return this.http.put(`${this.baseUrl}${url}`, data, this.httpOptions).pipe(map(res => res));
    }

    delete(url: string): Observable<any> {
        return this.http.delete(`${this.baseUrl}${url}`, this.httpOptions).pipe(map(res => res));
    }
}
