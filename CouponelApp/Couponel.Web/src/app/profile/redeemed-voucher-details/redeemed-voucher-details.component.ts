import {Component, OnDestroy, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {RedeemedVoucherService} from '../services/redeemed-voucher.service';
import {RedeemedVoucherModel} from '../models/redeemed-voucher/redeemed-voucher.model';

@Component({
  selector: 'app-redeemed-voucher-details',
  templateUrl: './redeemed-voucher-details.component.html',
  styleUrls: ['./redeemed-voucher-details.component.scss']
})
export class RedeemedVoucherDetailsComponent implements OnInit, OnDestroy {
  redeemedVoucherModel: RedeemedVoucherModel;
  constructor(
    private router: Router,
    private service: RedeemedVoucherService) { }

  ngOnInit(): void {
    const tmp = this.router.url.split('/').slice(-1)[0];
    console.log('from init::' + tmp);
    this.service.get(tmp).subscribe((data: RedeemedVoucherModel) => {
      console.log('from init.callService::' + tmp);
      this.redeemedVoucherModel = data;
      console.log(data);
    });
  }
  ngOnDestroy(): void {
  }

  updateRedeemedCoupon(): void {
    this.service.updateRedeemedCoupon(this.router.url.split('/').slice(-1)[0]).subscribe(() => {
      this.router.navigate(['profile/redeemed-vouchers']);
    });
    }

  deleteRedeemedCoupon(): void {
    this.service.deleteRedeemedCoupon(this.router.url.split('/').slice(-1)[0]).subscribe(() => {
      this.router.navigate(['profile/redeemed-vouchers']);
    });
  }
}
