import { Injectable, Inject, OnInit } from '@angular/core';
import { Http, Request, RequestOptionsArgs, Response, ResponseContentType, BaseRequestOptions, Headers, RequestMethod } from '@angular/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class GatewayService {

    constructor(protected http: Http,
        @Inject('BASE_URL') protected baseUrl: string, protected router: Router) {

    }

    get(url: string) {
        return this.http.get(`${this.baseUrl}${url}`).map(res => res.json());
    }

    post(url: string, data: any) {
        return this.http.post(`${this.baseUrl}${url}`, data).map(res => res.json());
    }

    put(url: string, data: any) {
        return this.http.put(`${this.baseUrl}${url}`, data).map(res => res.json());
    }   

    delete(url: string) {
        return this.http.delete(`${this.baseUrl}${url}`).map(res => res.json());
    }

    navigateHome() {
        this.router.navigate([this.baseUrl]);
    }
}