import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable} from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private usernameSubject: BehaviorSubject<string>;

  constructor() {
    this.usernameSubject = new BehaviorSubject<string>('');
    const userId = localStorage.getItem('userId');
    console.log(userId);

    if (userId != null){
      const dataUsername = localStorage.getItem('username');
      this.usernameSubject.next(dataUsername);
    }
  }

  public get username(): Observable<string>{
    return this.usernameSubject.asObservable();
  }

  public setUsername(value: string): void{
    this.usernameSubject.next(value);
  }

  public localStorageCleaning(): void {
    console.log('Local Storage cleaned successfully');
    localStorage.clear();
  }
}
