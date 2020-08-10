import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ProfileInfoService } from '../services/profile-info.service';
import { ProfileInfoModel } from '../models/profile-info.model';

@Component({
  selector: 'app-profile-info',
  templateUrl: './profile-info.component.html',
  styleUrls: ['./profile-info.component.scss'],
  providers: [ProfileInfoService,FormBuilder]
})
export class ProfileInfoComponent implements OnInit {
  public formGroup: FormGroup;
  public profileInfo: ProfileInfoModel;
  public isEditable=false;

  constructor(private readonly profileInfoService: ProfileInfoService,
    private readonly formBuilder: FormBuilder)
  {
    this.formGroup = this.formBuilder.group({
      username: new FormControl(null, [Validators.required, Validators.minLength(5)]),
      firstName: new FormControl(null, [Validators.required]),
      lastName: new FormControl(null, [Validators.required]),
      email: new FormControl(null, [Validators.required, Validators.email]),
      phoneNumber: new FormControl(null, [Validators.required]),
      role: new FormControl(null, Validators.required),
    });
  }

  ngOnInit(): void {
    const userId = localStorage.getItem('userId');
    this.profileInfoService.getProfilInfo(userId)
    .subscribe((data: ProfileInfoModel)=>{
      this.profileInfo=data;
      console.log(data);

    });

  }

  editInfo():void{
    this.isEditable=true;

    this.formGroup.controls['username'].setValue(this.profileInfo.userName);
    //de facut setvalue ptr fiecare camp de editat, campu tre sa fie in fromgroup mai sus
    //,cand folos formbuilder
  }

  //de creat o noua metoda de save care sa fie apelata cand apas save
  // apelez metoda de update din serviciu
}
