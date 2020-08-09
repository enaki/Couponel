import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';

import { VoucherModel } from '../models';
import { CommentModel } from '../models/comment.model';
import { VoucherService } from '../services/voucher.service';
import {RedeemedCouponModel} from "../models/redeemed-coupon.model";

@Component({
  selector: 'app-voucher-details',
  templateUrl: './voucher-details.component.html',
  styleUrls: ['./voucher-details.component.scss'],
  providers: [FormBuilder]
})

export class VoucherDetailsComponent implements OnInit, OnDestroy {
  isStudent: boolean;

  couponId: string;
  description: string;
  expirationDate: string;
  name: string;
  photos: Blob[] = [];

  private routeSub: Subscription = new Subscription();
  comments: CommentModel[];

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private service: VoucherService) { }

  ngOnInit(): void {
    this.name = 'dsasd';
    this.description = 'asdasd';
    this.expirationDate = 'dsaasd';
    if (localStorage.getItem('userRole') === 'Student')
    {
      this.isStudent = true;
      this.couponId = this.router.url.split('/').slice(-1)[0];
    }
  }

  ngOnDestroy(): void {
    this.routeSub.unsubscribe();
  }

  redeemCoupon(): void {
    const redeemedCouponData: RedeemedCouponModel = {
      couponId: this.couponId
    };
    this.service.redeemCoupon(redeemedCouponData).subscribe(() => {
      console.log('Omg it worked');
    });
  }
}
