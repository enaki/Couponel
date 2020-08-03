import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/services';

import { LoginModel } from '../models/login.model';
import { RegisterModel } from '../models/register.model';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.scss'],
  providers: [AuthenticationService],
})
export class AuthenticationComponent {
  public isSetRegistered: boolean = false;
  public isAdmin: boolean = false;
  public formGroup: FormGroup;

  constructor(
    private readonly router: Router,
    private readonly authenticationService: AuthenticationService,
    private readonly formBuilder: FormBuilder,
    private readonly userService: UserService
  ) {
    this.formGroup = this.formBuilder.group({
      username: new FormControl(null),
      firstName: new FormControl(null),
      lastName: new FormControl(null),
      email: new FormControl(null),
      password: new FormControl(null),
      userType: new FormControl(null),
    });
    this.userService.username.next('');
  }

  public setRegister(): void {
    this.isSetRegistered = !this.isSetRegistered;
  }

  public setAdmin(): void {
    this.isAdmin = !this.isAdmin;
  }

  public authenticate(): void {
    if (this.isSetRegistered) {
      const data: RegisterModel = this.formGroup.getRawValue();

      this.authenticationService.register(data).subscribe(() => {
        this.userService.username.next(data.username);
        this.router.navigate(['dashboard']);
      });
    } else {
      this.formGroup.removeControl('firstName');
      this.formGroup.removeControl('lastName');
      this.formGroup.removeControl('email');
      this.formGroup.removeControl('userType');

      const data: LoginModel = this.formGroup.getRawValue();

      this.authenticationService.login(data).subscribe((logData: any) => {
        localStorage.setItem('userToken', JSON.stringify(logData.token));
        this.userService.username.next(data.username);
        this.router.navigate(['dashboard']);
      });
    }
  }
}
