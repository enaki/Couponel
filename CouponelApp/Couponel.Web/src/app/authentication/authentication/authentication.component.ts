import {Component, OnInit} from '@angular/core';
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
export class AuthenticationComponent implements OnInit {
  public isSetRegistered = false;
  public isAdmin = false;
  public formGroup: FormGroup;

  ngOnInit(): void {
    const currentUser = this.userService.getUserDetails();
    console.log(currentUser);
    if (currentUser != null){
      this.setRegister();
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
    this.userService.setToken(null);
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
        // this.userService.setUsername(data.username);
        // this.userTokenService.setToken(logData.token);
        this.router.navigate(['authentication']);
      });
    } else {
      this.formGroup.removeControl('firstName');
      this.formGroup.removeControl('lastName');
      this.formGroup.removeControl('email');
      this.formGroup.removeControl('role');
      this.formGroup.removeControl('phoneNumber');

      const data: LoginModel = this.formGroup.getRawValue();

      this.authenticationService.login(data).subscribe((logData: any) => {
        this.userService.setToken(JSON.stringify(logData.token));
        this.router.navigate(['dashboard']);
      });
    }
  }
}
