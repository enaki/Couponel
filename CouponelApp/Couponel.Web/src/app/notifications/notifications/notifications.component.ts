import { Component, OnInit } from '@angular/core';
import {UserService} from '../../shared/services';
import {Router} from '@angular/router';

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.scss'],
})
export class NotificationsComponent implements OnInit {
  constructor(
    private router: Router,
    private readonly userService: UserService
  ) {
    const user = this.userService.getUserDetails();
    if (user == null){
      this.router.navigate(['authentication']);
    }
  }

  ngOnInit(): void {}
}
