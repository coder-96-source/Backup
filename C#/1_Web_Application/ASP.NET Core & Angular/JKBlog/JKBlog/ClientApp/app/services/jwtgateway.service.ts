import { Injectable, Inject } from '@angular/core';
import { Http, Request, RequestOptionsArgs, Response, ResponseContentType, BaseRequestOptions, Headers, RequestMethod } from '@angular/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { GatewayService } from './gateway.service';
import { UserService } from './user.service';

@Injectable()
export class JWTGatewayService extends GatewayService {
    private reqOptions: RequestOptionsArgs = {};

    constructor(protected http: Http, @Inject('BASE_URL')
    protected baseUrl: string, protected router: Router, private userService: UserService) {
        super(http, baseUrl, router);
        this.makeDefaultHttpOption();
    }

    makeDefaultHttpOption() {
        //const authToken = localStorage.getItem('auth_token');
        const jwtToken = this.userService.getJwtToken;
        const headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append('Authorization', `Bearer ${jwtToken}`);
        this.reqOptions.headers = headers;
    }

    get(url: string) {
        return this.http.get(`${this.baseUrl}${url}`, this.reqOptions).map(res => res.json());
    }

    post(url: string, data: any) {
        return this.http.post(`${this.baseUrl}${url}`, data, this.reqOptions).map(res => res.json());;
    }

    put(url: string, data: any) {
        return this.http.put(`${this.baseUrl}${url}`, data, this.reqOptions).map(res => res.json());;
    }

    delete(url: string) {
        return this.http.delete(`${this.baseUrl}${url}`, this.reqOptions).map(res => res.json());;
    }
}