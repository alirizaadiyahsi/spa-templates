import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';

import { RegisterModel } from '../models/register-model';
import { BaseService } from "./base-service";

import { Observable } from 'rxjs/Rx';
import { BehaviorSubject } from 'rxjs/Rx';

// Add the RxJS Observable operators we need in this app.
import 'rxjs/Rx';

@Injectable()

export class UserService extends BaseService {

    // Observable navItem source
    private authNavStatusSource = new BehaviorSubject<boolean>(false);
    // Observable navItem stream
    authNavStatus$ = this.authNavStatusSource.asObservable();

    private loggedIn = false;

    constructor(private readonly http: Http) {
        super();
        this.loggedIn = !!localStorage.getItem('auth_token');
        // ?? not sure if this the best way to broadcast the status but seems to resolve issue on page refresh where auth status is lost in
        // header component resulting in authed user nav links disappearing despite the fact user is still logged in
        this.authNavStatusSource.next(this.loggedIn);
    }

    register(email: string, password: string, userName: string): Observable<RegisterModel> {
        const body = JSON.stringify({ email, password, userName });
        const headers = new Headers({ 'Content-Type': 'application/json' });
        const options = new RequestOptions({ headers: headers });

        return this.http.post(this.baseUrl + "/account", body, options)
            .map(res => true)
            .catch(this.handleError);
    }

    login(userName: string, password: string) {
        const headers = new Headers();
        headers.append('Content-Type', 'application/json');

        return this.http
            .post(
            this.baseUrl + '/tokenAuth/login',
            JSON.stringify({ userName, password }), { headers }
            )
            .map(res => res.json())
            .map(res => {
                localStorage.setItem('auth_token', res.auth_token);
                this.loggedIn = true;
                this.authNavStatusSource.next(true);
                return true;
            })
            .catch(this.handleError);
    }

    logout() {
        localStorage.removeItem('auth_token');
        this.loggedIn = false;
        this.authNavStatusSource.next(false);
    }

    isLoggedIn() {
        return this.loggedIn;
    }
}

