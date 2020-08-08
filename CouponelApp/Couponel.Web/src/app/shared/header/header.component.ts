import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  OnInit,
} from '@angular/core';
import { Router } from '@angular/router';

import { UserService } from '../services';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent {
  constructor(
    private readonly router: Router,
    private readonly cdRef: ChangeDetectorRef,
    public readonly userService: UserService
  ) {}
  public username: string;

  private static localStorageCleaning(): void {
    console.log('Local Storage cleaned successfully');
    localStorage.removeItem('email');
    localStorage.removeItem('username');
    localStorage.removeItem('firstName');
    localStorage.removeItem('lastName');
    localStorage.removeItem('token');
    localStorage.removeItem('userId');
    localStorage.removeItem('userRole');
  }

  public logout(): void {
    this.router.navigate(['authentication']);
    HeaderComponent.localStorageCleaning();
    this.username = localStorage.getItem('username');
  }

  public goToPage(page: string): void {
    this.router.navigate([page]);
  }
}
