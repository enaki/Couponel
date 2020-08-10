import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable} from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TokenService {
  private tokenSubject: BehaviorSubject<any>;

  constructor() {
    this.tokenSubject = new BehaviorSubject<any>('');
    const userId = localStorage.getItem('userId');
    if (userId != null){
      const dataToken = localStorage.getItem('userToken');
      this.tokenSubject.next(dataToken);
    }
  }

  public get token(): Observable<any>{
    return this.tokenSubject.asObservable();
  }

  public setToken(): void{
    const dataToken = localStorage.getItem('userToken');
    this.tokenSubject.next(dataToken);
  }
}
