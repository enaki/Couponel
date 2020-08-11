import {Component, OnDestroy, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import {UserService} from '../../shared/services';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})

export class DashboardComponent implements OnInit, OnDestroy{
  isStudent: boolean = false;
  isOfferer: boolean = false;
  isAdmin: boolean = false;

  constructor(private router: Router, private readonly userService: UserService) {}

  public goToPage(page: string): void {
    this.router.navigate([page]);
  }

  ngOnInit(): void {
    const user = this.userService.getUserDetails();
    this.isStudent = this.isOfferer = this.isOfferer = false;
    if (user != null){
      this.isStudent = user.role === 'Student';
      this.isOfferer = user.role === 'Offerer';
      this.isAdmin = user.role === 'Admin';
    } else {
      this.goToPage('authentication');
    }
  }

  ngOnDestroy(): void {
  }
}
