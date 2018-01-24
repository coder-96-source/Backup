import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { User } from '../models/dataModel/user';

import { Observable } from 'rxjs/Rx';
import { BehaviorSubject } from 'rxjs/Rx';

@Injectable()

export class UserService {
    private _authNavStatusSource = new BehaviorSubject<boolean>(false);     // Observable navItem source
    private loggedIn = false;

    authNavStatus$ = this._authNavStatusSource.asObservable(); // Observable navItem stream
    baseUrl: string;

    constructor(private http: Http) {
        this.loggedIn = !!localStorage.getItem('auth_token');
        this._authNavStatusSource.next(this.loggedIn);
        this.baseUrl = "http://localhost:52386/";
    }

    register(name: string, password: string, birthdate: Date) {
        let body = JSON.stringify({ name, password, birthdate });
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.baseUrl + "/api/users/postuser", body, options).map(res => true);
    }

    login(name: string, password: string) {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');

        return this.http
            .post(
            this.baseUrl + '/api/admin/login',
            JSON.stringify({ name, password }), { headers }
            )
            .map(res => res.json())
            .map(res => {
                localStorage.setItem('auth_token', res.auth_token);
                this.loggedIn = true;
                this._authNavStatusSource.next(true);
                return true;
            });
    }

    logout() {
        localStorage.removeItem('auth_token');
        this.loggedIn = false;
        this._authNavStatusSource.next(false);
    }

    isLoggedIn() {
        return this.loggedIn;
    }
}

