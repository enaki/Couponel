import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import * as jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  public endpoint =
        'https://localhost:5001/api/v1/auth';
  constructor(private readonly httpClient: HttpClient) {}

  public login(data: unknown): Observable<unknown> {
    return this.httpClient.post(`${this.endpoint}/login`, data);
  }

  public setSessionTokenInfo(token: string): void {
    const tokenData = jwt_decode(token);
    console.log(tokenData);
    localStorage.setItem('userId', tokenData.userId);
    localStorage.setItem('userRole', tokenData.userRole);
    localStorage.setItem('username', tokenData.userName);
    localStorage.setItem('firstName', tokenData.firstName);
    localStorage.setItem('lastName', tokenData.lastName);
  }

  public register(data: unknown): Observable<unknown> {
    console.log(data);
    return this.httpClient.post(`${this.endpoint}/register`, data);
  }
}
