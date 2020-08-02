import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { VoucherModel, VouchersModel } from '../models';
import { VoucherService } from '../services/voucher.service';

@Component({
  selector: 'app-voucher-list',
  templateUrl: './voucher-list.component.html',
  styleUrls: ['./voucher-list.component.scss'],
  providers: [VoucherService]
})
export class VoucherListComponent implements OnInit {
  public voucherList: VoucherModel[];

  constructor(
    private router: Router,
    private service: VoucherService) { }

  public ngOnInit(): void {
    this.service.getAll().subscribe((data: VouchersModel) => {
      this.voucherList = data.results;
    });
  }

  goToVoucher(id: string): void {
    this.router.navigate([`/voucher/details/${id}`]);
  }
}
