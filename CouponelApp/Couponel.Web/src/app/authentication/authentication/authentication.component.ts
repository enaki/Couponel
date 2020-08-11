import {Component, OnInit} from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/services';

import { LoginModel } from '../models/login.model';
import { RegisterModel } from '../models/register.model';
import { AuthenticationService } from '../services/authentication.service';
import {UniversityService} from '../../shared/services/university.service';
import {UniversityModel} from '../../shared/models/university.model';
import {FacultyModel} from "../../shared/models/faculty.model";

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.scss'],
  providers: [AuthenticationService],
})
export class AuthenticationComponent implements OnInit {
  public isSetRegistered = false;
  public isOfferer = false;
  public isSelected = false;
  public selectedUniversityId: string;
  public formGroup: FormGroup;
  public universities: UniversityModel[];
  public faculties: FacultyModel[];

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
    private readonly userService: UserService,
    private readonly universityService: UniversityService
  ) {
    this.universityService.getAll().subscribe((data: UniversityModel[]) => {
      this.universities = data;
      console.log(this.universities);
    });
    this.formGroup = this.formBuilder.group({
      username: new FormControl(null, [Validators.required, Validators.minLength(5)]),
      firstName: new FormControl(null, [Validators.required]),
      lastName: new FormControl(null, [Validators.required]),
      email: new FormControl(null, [Validators.required, Validators.email]),
      password: new FormControl(null, [Validators.required, Validators.minLength(5)]),
      phoneNumber: new FormControl(null, [Validators.required]),
      role: new FormControl(null, Validators.required),
      facultyId: new FormControl(null),
      universityId: new FormControl(null),
    });
    this.userService.setToken(null);
  }

  public setRegister(): void {
    this.isSetRegistered = !this.isSetRegistered;
  }

  public setOfferer(): void {
    this.isOfferer = !this.isOfferer;
  }

  public authenticate(): void {
    if (this.isSetRegistered) {
      if (!this.isOfferer){
        this.formGroup.controls.role.setValue('Offerer');
        this.formGroup.removeControl('universityId');
        this.formGroup.removeControl('facultyId');
      }
      else{
        this.formGroup.controls.role.setValue('Student');
      }
      const data: RegisterModel = this.formGroup.getRawValue();
      this.authenticationService.register(data).subscribe(() => {
        this.router.navigate(['authentication']);
      });
    } else {
      this.formGroup.removeControl('firstName');
      this.formGroup.removeControl('lastName');
      this.formGroup.removeControl('email');
      this.formGroup.removeControl('role');
      this.formGroup.removeControl('phoneNumber');
      this.formGroup.removeControl('universityId');
      this.formGroup.removeControl('facultyId');

      const data: LoginModel = this.formGroup.getRawValue();

      this.authenticationService.login(data).subscribe((logData: any) => {

        this.userService.setToken(JSON.stringify(logData.token));
        this.router.navigate(['dashboard']);
      }, error => alert('Eroare la conectare. \n Username/parola incorecta.'));
    }
  }

  public setSelectedUniversityId(id: string): void {
    if (id === 'notuniversity') {
      this.isSelected = false;
    }
    else {
      this.isSelected = true;
      this.selectedUniversityId = id;
      Object.keys(this.universities).forEach(key => {
        if (this.universities[key].id === this.selectedUniversityId) {
          this.faculties = this.universities[key].faculties;
        }
      });
    }
  }
}
