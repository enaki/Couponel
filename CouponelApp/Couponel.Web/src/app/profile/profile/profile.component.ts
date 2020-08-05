import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  public goToPage(page: string): void {
    this.router.navigate([page]);
  }
}
