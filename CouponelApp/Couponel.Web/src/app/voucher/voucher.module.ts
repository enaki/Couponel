import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../shared/shared.module';
import { VoucherDetailsComponent } from './voucher-details/voucher-details.component';
import { VoucherListComponent } from './voucher-list/voucher-list.component';
import { VoucherRoutingModule } from './voucher-routing.module';
import { TopComponent } from './top/top.component';
import { DialogComponent } from './dialog/dialog.component';

import {MatDialogModule, MatDialogRef} from '@angular/material/dialog';


@NgModule({
  declarations: [VoucherDetailsComponent, VoucherListComponent, TopComponent, DialogComponent],
  imports: [CommonModule, VoucherRoutingModule, FormsModule, ReactiveFormsModule, SharedModule, MatDialogModule],
  exports: [VoucherDetailsComponent, VoucherListComponent],
})
export class VoucherModule { }
