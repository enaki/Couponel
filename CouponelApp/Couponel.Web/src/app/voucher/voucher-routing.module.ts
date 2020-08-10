import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { VoucherDetailsComponent } from './voucher-details/voucher-details.component';
import { VoucherListComponent } from './voucher-list/voucher-list.component';
import { TopComponent } from './top/top.component';
import {VoucherCreateComponent} from '../profile/voucher-create/voucher-create.component';


const routes: Routes = [
  {
    path: 'list',
    pathMatch: 'full',
    component: VoucherListComponent,
  },
  {
    path: 'details/:id',
    pathMatch: 'full',
    component: VoucherDetailsComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class VoucherRoutingModule { }
