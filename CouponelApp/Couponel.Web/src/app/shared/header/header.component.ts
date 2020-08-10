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

  ngOnInit(): void {
    console.log('HeaderComponent::ngOnInit');
    this.userService.username.subscribe((name) => {
      this.username = name;
    });
  }

  public logout(): void {
    this.userService.localStorageCleaning();
    this.router.navigate(['authentication']);
  }

  public goToPage(page: string): void {
    this.router.navigate([page]);
  }
}
