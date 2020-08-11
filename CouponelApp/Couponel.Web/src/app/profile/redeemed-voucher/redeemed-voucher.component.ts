import {Component, OnInit} from '@angular/core';
import {RedeemedVoucherModel} from '../models/redeemed-voucher/redeemed-voucher.model';
import {RedeemedVoucherService} from '../services/redeemed-voucher.service';
import {Router} from '@angular/router';
import {VoucherImageProvider} from '../../voucher/services/voucher-image-provider';
import {UserService} from '../../shared/services';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-redeemed-voucher',
  templateUrl: './redeemed-voucher.component.html',
  styleUrls: ['./redeemed-voucher.component.scss']
})
export class RedeemedVoucherComponent implements OnInit {
  redeemedVoucherList: RedeemedVoucherModel[];
  redeemedVoucherListOrig: RedeemedVoucherModel[];
  public formGroup: FormGroup;

  constructor(
    private router: Router,
    private userService: UserService,
    private service: RedeemedVoucherService,
    private readonly formBuilder: FormBuilder,
    private imageProvider: VoucherImageProvider) {
    this.formGroup = this.formBuilder.group({
      couponStatus: new FormControl(null, [Validators.required, Validators.email]),
    });
    const user = this.userService.getUserDetails();
    if (user == null) {
      this.router.navigate(['authentication']);
    }
  }

  ngOnInit(): void {
    this.service.getAll().subscribe((data: RedeemedVoucherModel[]) => {
      console.log(data);
      this.redeemedVoucherListOrig = data;
      this.redeemedVoucherList = this.redeemedVoucherListOrig;
    });
  }

  getCategoryImage(category: any): string {
    return this.imageProvider.getCategoryImage(category);
  }

  goToVoucher(id: string): void {
    this.router.navigate([`profile/redeemed-vouchers/details/${id}`]);
  }

  filterRedeemedCoupons(): void {
    const dataToSearch = this.formGroup.controls.couponStatus.value;
    console.log(dataToSearch);
    if (dataToSearch === 'NotSelected'){
      this.redeemedVoucherList = this.redeemedVoucherListOrig;
    } else {
      this.redeemedVoucherList = this.redeemedVoucherListOrig.filter(voucher => voucher.status === dataToSearch);
    }
  }
}
