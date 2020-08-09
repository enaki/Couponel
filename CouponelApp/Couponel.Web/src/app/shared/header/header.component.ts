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
export class HeaderComponent implements OnInit{
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

  ngOnInit(): void {
    console.log('HeaderComponent::ngOnInit');
    const userId = localStorage.getItem('userId');
    console.log(userId);
    if (userId != null){
      this.username = localStorage.getItem('username');

      // the most important f* line of code <3
      // Method 1:
      // setTimeout(() => this.userService.username.next(this.username), 0);

      // Method 2
      new Promise(resolve => { resolve(); }).then(() => {
        this.userService.username.next(this.username);
      });
    }
  }

  public logout(): void {
    this.router.navigate(['authentication']);
    HeaderComponent.localStorageCleaning();
    this.userService.username.next(null);
  }

  public goToPage(page: string): void {
    this.router.navigate([page]);
  }
}
