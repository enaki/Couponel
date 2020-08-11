import { Component, OnInit } from '@angular/core';
import {RedeemedVoucherModel} from '../models/redeemed-voucher/redeemed-voucher.model';
import {RedeemedVoucherService} from '../services/redeemed-voucher.service';
import {Router} from '@angular/router';
import {VoucherImageProvider} from '../../voucher/services/voucher-image-provider';
import {UserService} from '../../shared/services';

@Component({
  selector: 'app-redeemed-voucher',
  templateUrl: './redeemed-voucher.component.html',
  styleUrls: ['./redeemed-voucher.component.scss']
})
export class RedeemedVoucherComponent implements OnInit {
  redeemedVoucherList: RedeemedVoucherModel[];
constructor(
  private router: Router,
  private userService: UserService,
  private service: RedeemedVoucherService,
  private imageProvider: VoucherImageProvider) {
  const user = this.userService.getUserDetails();
  if (user == null){
    this.router.navigate(['authentication']);
  }
}

  ngOnInit(): void {
    this.service.getAll().subscribe((data: RedeemedVoucherModel[]) => {
      console.log(data);
      this.redeemedVoucherList = data;
    });
  }

  getCategoryImage(category: any): string {
    return this.imageProvider.getCategoryImage(category);
  }

  goToVoucher(id: string): void {
    this.router.navigate([`profile/redeemed-vouchers/details/${id}`]);
  }
}
