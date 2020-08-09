import {Component, OnDestroy, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import {VoucherModel} from "../../voucher/models";


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})

export class DashboardComponent implements OnInit, OnDestroy{
  isStudent: boolean;
  isOfferer: boolean;
  isAdmin: boolean;

  constructor(private router: Router) {}

  public goToPage(page: string): void {
    this.router.navigate([page]);
  }

  ngOnInit(): void {
    if (localStorage.getItem('userRole') === 'Student')
    {
      this.isStudent = true;
    }
    else if (localStorage.getItem('userRole') === 'Offerer')
    {
      this.isOfferer = true;
    }
    else if (localStorage.getItem('userRole') === 'Admin')
    {
      this.isAdmin = true;
    }
  }
  ngOnDestroy(): void {
  }
}
