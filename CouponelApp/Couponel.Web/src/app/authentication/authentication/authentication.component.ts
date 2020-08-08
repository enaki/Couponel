import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
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
  public isSetRegistered = false;
  public isAdmin = false;
  public formGroup: FormGroup;

  // tslint:disable-next-line:use-lifecycle-interface
  ngOnInit(): void {
    const currentUser = localStorage.getItem('userId');
    console.log(localStorage.getItem('username'));
    if (currentUser != null){
      this.setRegister();
      this.userService.username.next(localStorage.getItem('username'));
      this.router.navigate(['dashboard']);
    }
  }

  constructor(
    private readonly router: Router,
    private readonly authenticationService: AuthenticationService,
    private readonly formBuilder: FormBuilder,
    private readonly userService: UserService
  ) {
    this.formGroup = this.formBuilder.group({
      username: new FormControl(null, [Validators.required, Validators.minLength(5)]),
      firstName: new FormControl(null, [Validators.required]),
      lastName: new FormControl(null, [Validators.required]),
      email: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null, [Validators.required, Validators.minLength(5)]),
      phoneNumber: new FormControl(null, [Validators.required]),
      role: new FormControl(null, Validators.required),
    });
    this.userService.username.next('');
  }

  public setRegister(): void {
    this.isSetRegistered = true;
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
      this.formGroup.removeControl('role');
      this.formGroup.removeControl('phoneNumber');

      const data: LoginModel = this.formGroup.getRawValue();

      this.authenticationService.login(data).subscribe((logData: any) => {
        localStorage.setItem('userToken', JSON.stringify(logData.token));
        this.authenticationService.setSessionTokenInfo(JSON.stringify(logData.token));
        this.userService.username.next(data.username);
        this.router.navigate(['dashboard']);
      });
    }
  }
}
