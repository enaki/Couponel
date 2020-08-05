import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProfileRoutingModule } from './profile-routing.module';
import { ProfileComponent } from './profile/profile.component';

import { SharedModule } from '../shared/shared.module';
import { MatIconModule } from '@angular/material/icon';
import { ProfileInfoComponent } from './profile-info/profile-info.component';
import { SavedVouchersComponent } from './saved-vouchers/saved-vouchers.component';

@NgModule({
  declarations: [ProfileComponent, ProfileInfoComponent, SavedVouchersComponent],
  imports: [
    CommonModule,
    ProfileRoutingModule,
    SharedModule
  ]
})
export class ProfileModule { }
