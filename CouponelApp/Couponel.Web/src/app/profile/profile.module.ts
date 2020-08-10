import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProfileRoutingModule } from './profile-routing.module';
import { ProfileComponent } from './profile/profile.component';

import { SharedModule } from '../shared/shared.module';
import { MatIconModule } from '@angular/material/icon';
import { ProfileInfoComponent } from './profile-info/profile-info.component';
import { SavedVouchersComponent } from './saved-vouchers/saved-vouchers.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
  declarations: [ProfileComponent, ProfileInfoComponent, SavedVouchersComponent],
  imports: [
    CommonModule,
    ProfileRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class ProfileModule { }
