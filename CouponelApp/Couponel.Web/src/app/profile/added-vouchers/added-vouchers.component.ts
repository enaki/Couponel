import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {VoucherImageProvider} from '../../voucher/services/voucher-image-provider';
import {VoucherModel} from '../../voucher/models';
import {OffererVouchersService} from '../services/offerer-vouchers.service';
import {OffererCouponsModel} from '../models/voucher/offerer-coupons.model';
import {UserService} from '../../shared/services';

@Component({
  selector: 'app-added-vouchers',
  templateUrl: './added-vouchers.component.html',
  styleUrls: ['./added-vouchers.component.scss']
})
export class AddedVouchersComponent implements OnInit {
  voucherList: VoucherModel[];
  constructor(
    private router: Router,
    private service: OffererVouchersService,
    private userService: UserService,
    private imageProvider: VoucherImageProvider) {
    const user = this.userService.getUserDetails();
    if (user == null){
      this.router.navigate(['authentication']);
    }
  }

  ngOnInit(): void {
    this.service.getAllVouchers().subscribe((data: OffererCouponsModel) => {
      this.voucherList = data.coupons;
    });
  }

  getCategoryImage(category: any): string{
    return this.imageProvider.getCategoryImage(category);
  }

  goToVoucher(id: string): void {
    this.router.navigate([`profile/added-vouchers/details/${id}`]);
  }
}
