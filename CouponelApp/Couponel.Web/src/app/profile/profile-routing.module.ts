import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProfileComponent } from './profile/profile.component';
import {VoucherCreateComponent} from './voucher-create/voucher-create.component';
import {RedeemedVoucherComponent} from './redeemed-voucher/redeemed-voucher.component';
import {RedeemedVoucherDetailsComponent} from './redeemed-voucher-details/redeemed-voucher-details.component';
import {AddedVouchersComponent} from './added-vouchers/added-vouchers.component';
import {AddedVoucherDetailsComponent} from "./added-voucher-details/added-voucher-details.component";

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: ProfileComponent
  },
  {
    path: 'create-voucher',
    pathMatch: 'full',
    component: VoucherCreateComponent,
  },
  {
    path: 'redeemed-vouchers',
    pathMatch: 'full',
    component: RedeemedVoucherComponent
  },
  {
    path: 'redeemed-vouchers/details/:id',
    pathMatch: 'full',
    component: RedeemedVoucherDetailsComponent
  },
  {
    path: 'added-vouchers',
    pathMatch: 'full',
    component: AddedVouchersComponent
  },
  {
    path: 'added-vouchers/details/:id',
    pathMatch: 'full',
    component: AddedVoucherDetailsComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfileRoutingModule { }
