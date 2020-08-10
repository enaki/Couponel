import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../shared/shared.module';
import { VoucherDetailsComponent } from './voucher-details/voucher-details.component';
import { VoucherListComponent } from './voucher-list/voucher-list.component';
import { VoucherRoutingModule } from './voucher-routing.module';
import { TopComponent } from './top/top.component';
import { RedeemedVoucherComponent } from './redeemed-voucher/redeemed-voucher.component';
import { RedeemedVoucherDetailsComponent } from './redeemed-voucher-details/redeemed-voucher-details.component';
import { VoucherCreateComponent } from './voucher-create/voucher-create.component';


@NgModule({
  declarations: [VoucherDetailsComponent, VoucherListComponent, TopComponent, VoucherCreateComponent, RedeemedVoucherComponent, RedeemedVoucherDetailsComponent],
  imports: [CommonModule, VoucherRoutingModule, FormsModule, ReactiveFormsModule, SharedModule],
  exports: [VoucherDetailsComponent, VoucherListComponent],
})
export class VoucherModule { }
