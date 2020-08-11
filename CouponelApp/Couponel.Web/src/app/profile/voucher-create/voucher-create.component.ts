import {Component, OnDestroy, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {VoucherService} from '../../voucher/services/voucher.service';
import {CreateCouponModel} from '../models/voucher/create.coupon.model';
import {VoucherModel} from '../../voucher/models';

@Component({
  selector: 'app-voucher-create',
  templateUrl: './voucher-create.component.html',
  styleUrls: ['./voucher-create.component.scss'],
  providers: [VoucherService]
})
export class VoucherCreateComponent implements OnInit, OnDestroy {
  formGroup: FormGroup;
  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private service: VoucherService
    ) {
    this.formGroup = this.formBuilder.group({
      Name: new FormControl(null, [Validators.required, Validators.minLength(5)]),
      Category: new FormControl(null, [Validators.required, Validators.minLength(5),
          Validators.pattern('^(?:Electronics|Fashion|Entertainment|Food|Coffee&Snack|Accessories|Home|Sport|Others|Auto)$')]),
      ExpirationDate: new FormControl(null, [Validators.required]),
      Description: new FormControl(null, [Validators.required, Validators.minLength(5)]),
    });
  }

  ngOnInit(): void {
  }
  createVoucher(): void {
    const data: CreateCouponModel = this.formGroup.getRawValue();
    this.service.createVoucher(data).subscribe(() => {
      this.router.navigate(['profile/added-vouchers']);
    });
  }
  ngOnDestroy(): void {
  }

}
