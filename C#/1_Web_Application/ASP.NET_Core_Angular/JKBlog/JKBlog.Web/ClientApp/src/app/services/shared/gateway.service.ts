import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from "rxjs";
import { map } from "rxjs/operators";

@Injectable()
export class GatewayService {

    constructor(protected http: HttpClient,
        @Inject('BASE_URL') protected baseUrl: string,
        protected router: Router) {

    }

    get(url: string) {
        return this.http.get(`${this.baseUrl}${url}`).pipe(map(res => res));
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
}
