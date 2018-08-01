import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { LoginModel } from "./models/login.model";
import { RegisterModel } from "./models/register.model";

const appKey = "" // APP KEY HERE;
const appSecret = "" // APP SECRET HERE;
const registerUrl = `https://baas.kinvey.com/user/${appKey}`;
const loginUrl = `https://baas.kinvey.com/user/${appKey}/login`;
const logoutUrl = `https://baas.kinvey.com/user/${appKey}/_logout`;


@Injectable()
export class AuthService {
    private currentAuthtoken: string

    constructor(private http: HttpClient) { }

    login(model: LoginModel) {
        return this.http.post(loginUrl,
            JSON.stringify(model),
            { headers: this.createAuthHeader('Basic') })
    }

    register(model: RegisterModel) {
        return this.http.post(registerUrl,
            JSON.stringify(model),
            { headers: this.createAuthHeader('Basic') })
    }

    logout() {
        return this.http.post(logoutUrl, {}, { headers: this.createAuthHeader('Kinvey') })
    }

    checkedIfLogged() {
        return this.currentAuthtoken === localStorage.getItem('authtoken')
    }

    get authtoken() {
        return this.currentAuthtoken
    }

    set authtoken(value: string) {
        this.currentAuthtoken = value
    }

    private createAuthHeader(type: string): HttpHeaders {
        if (type === 'Basic') {
            return new HttpHeaders({
                'Authorization': `Basic ${btoa(`${appKey}:${appSecret}`)}`,
                'Content-Type': 'application/json'
            })
        } else {
            return new HttpHeaders({
                'Authorization': `Kinvey ${localStorage.getItem('authtoken')}`,
                'Content-Type': 'application/json'
            })
        }
    }
}