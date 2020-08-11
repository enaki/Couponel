import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ProfileInfoService } from '../services/profile-info.service';
import { ProfileInfoModel } from '../models/profile-info.model';
import {UpdateProfileInfoModel} from '../models/update-profile-info.model';
import {Router} from '@angular/router';

@Component({
  selector: 'app-profile-info',
  templateUrl: './profile-info.component.html',
  styleUrls: ['./profile-info.component.scss'],
  providers: [ProfileInfoService, FormBuilder]
})
export class ProfileInfoComponent implements OnInit {
  public formGroup: FormGroup;
  public profileInfo: ProfileInfoModel;
  public isEditable = false;
  public isError = false;

  constructor(private readonly profileInfoService: ProfileInfoService,
              private router: Router,
              private readonly formBuilder: FormBuilder)
  {
    this.formGroup = this.formBuilder.group({
      email: new FormControl(null, [Validators.required, Validators.email]),
      firstName: new FormControl(null, [Validators.required]),
      lastName: new FormControl(null, [Validators.required]),
      confirmPassword: new FormControl(null, [Validators.required]),
      password: new FormControl(null, [Validators.required]),
      phoneNumber: new FormControl(null, [Validators.required]),
      country: new FormControl(null, [Validators.required]),
      city: new FormControl(null, [Validators.required]),
      street: new FormControl(null, [Validators.required]),
      number: new FormControl(null, [Validators.required]),
    });
  }

  ngOnInit(): void {
    const userId = JSON.parse(localStorage.getItem('user')).userId;
    this.profileInfoService.getProfileInfo(userId)
    .subscribe((data: ProfileInfoModel) => {
      this.profileInfo = data;
      console.log(data);
    });
  }

  editInfo(): void{
    this.isEditable = true;
    this.isError = false;
    this.formGroup.controls.email.setValue(this.profileInfo.email);
    this.formGroup.controls.firstName.setValue(this.profileInfo.firstName);
    this.formGroup.controls.lastName.setValue(this.profileInfo.lastName);
    this.formGroup.controls.phoneNumber.setValue(this.profileInfo.phoneNumber);
    this.formGroup.controls.country.setValue(this.profileInfo.address.country);
    this.formGroup.controls.city.setValue(this.profileInfo.address.city);
    this.formGroup.controls.street.setValue(this.profileInfo.address.street);
    this.formGroup.controls.number.setValue(this.profileInfo.address.number);
    this.formGroup.controls.password.setValue('');
    this.formGroup.controls.confirmPassword.setValue('');
  }

  saveInfo(): void{
    const data: any = this.formGroup.getRawValue();
    const dataToSend: UpdateProfileInfoModel = {
      email: data.email,
      firstName: data.firstName,
      lastName: data.lastName,
      password: data.password,
      confirmPassword: data.confirmPassword,
      phoneNumber: data.phoneNumber,
      address: {
        country: data.country,
        city: data.city,
        street: data.street,
        number: data.number,
      }
    };
    this.profileInfoService.updateProfileInfo(dataToSend).subscribe(() => {
      console.log('I am here');
      this.back();
      window.location.reload();
    }, () => {
      this.isError = true;
      this.back();
    });
  }

  back(): void {
    this.isEditable = !this.isEditable;
  }
}
