import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {RedeemedVoucherService} from '../services/redeemed-voucher.service';
import {RedeemedVoucherModel} from '../models/redeemed-voucher/redeemed-voucher.model';

@Component({
  selector: 'app-redeemed-voucher-details',
  templateUrl: './redeemed-voucher-details.component.html',
  styleUrls: ['./redeemed-voucher-details.component.scss']
})
export class RedeemedVoucherDetailsComponent implements OnInit {
  redeemedVoucherModel: RedeemedVoucherModel;
  constructor(
    private router: Router,
    private service: RedeemedVoucherService) { }

  ngOnInit(): void {
    this.service.get(this.router.url.split('/').slice(-1)[0]).subscribe((data: RedeemedVoucherModel) => {
      this.redeemedVoucherModel = data;
      console.log(this.redeemedVoucherModel);
    });
  }

  updateRedeemedCoupon(): void {
  }

  deleteRedeemedCoupon(): void {
    this.service.deleteRedeemedCoupon(this.router.url.split('/').slice(-1)[0]).subscribe(() => {
      console.log('Received message from Redeemed Coupon Delete');
      this.router.navigate(['my-vouchers']);
    });
  }
}
