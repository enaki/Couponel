import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable, Subject} from 'rxjs';
import * as jwt_decode from 'jwt-decode';
import {UserModel} from '../models/user.model';
import {HttpHeaders} from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private tokenSubject: BehaviorSubject<string>;

  constructor() {
    this.tokenSubject = new BehaviorSubject<string>('');
    const token = localStorage.getItem('userToken');
    console.log('UserService Constructor: ' + token);
    if (token != null){
      this.setToken(token);
    }
  }

  public setToken(token: string): void {
    if (token != null){
      localStorage.setItem('userToken', token);
      const tokenData = jwt_decode(token) as any;
      console.log(tokenData);
      const user: UserModel = {
        userId: tokenData.userId,
        username: tokenData.userName,
        email: tokenData.email,
        firstName: tokenData.firstName,
        lastName: tokenData.lastName,
        userRole: tokenData.userRole
      };
      localStorage.setItem('user', JSON.stringify(user));
      this.tokenSubject.next(token);
    } else {
      this.localStorageCleaning();
    }
  }

  public get token(): Observable<string>{
    return this.tokenSubject.asObservable();
  }

  public getUserDetails(): UserModel{
    const data = localStorage.getItem('user');
    return (data == null) ? null : JSON.parse(data);
  }

  public localStorageCleaning(): void {
    this.tokenSubject.next(null);
    console.log('Local Storage cleaned successfully');
    localStorage.clear();
  }

  public getHttpOptions(): any{
    if (this.tokenSubject.value != null){
      return { headers: new HttpHeaders({'Content-Type': 'application/json',
          Authorization: `Bearer ${JSON.parse(this.tokenSubject.value)}` })};
    } else {
      return { headers: new HttpHeaders({'Content-Type': 'application/json' })};
    }
  }
}
