import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.scss']
})
export class WelcomeComponent implements OnInit {

  constructor( private readonly router: Router,
    ) { }

  ngOnInit(): void {
  }

  public gotoAuthenticate():void {
      this.router.navigate(['authentication']);
  }
}
