import {Injectable, OnDestroy, OnInit} from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService implements OnInit, OnDestroy {
  public username: Subject<string>;

  constructor() {
    this.username = new Subject<string>();
  }

  ngOnInit(): void {
    console.log("User ngOnInit");
  }

  ngOnDestroy(): void {
    console.log("User on destroy");
  }


}
