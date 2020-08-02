import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../shared/shared.module';
import { VoucherDetailsComponent } from './voucher-details/voucher-details.component';
import { VoucherListComponent } from './voucher-list/voucher-list.component';
import { VoucherRoutingModule } from './voucher-routing.module';
import { TopComponent } from './top/top.component';

@NgModule({
  declarations: [VoucherDetailsComponent, VoucherListComponent, TopComponent],
  imports: [CommonModule, VoucherRoutingModule, FormsModule, ReactiveFormsModule, SharedModule],
  exports: [VoucherDetailsComponent, VoucherListComponent],
})
export class VoucherModule { }
