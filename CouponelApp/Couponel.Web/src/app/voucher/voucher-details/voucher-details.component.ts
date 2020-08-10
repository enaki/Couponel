import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';

import { VoucherModel } from '../models';
import { CommentModel } from '../models/comment.model';
import { VoucherService } from '../services/voucher.service';
import {RedeemedCouponModel} from '../models/redeemed-coupon.model';
import {CreateCommentModel} from "../models/create.comment.model";
import {RegisterModel} from "../../authentication/models/register.model";

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
  comments: CommentModel[];
  photos: Blob[] = [];

  commentFormGroup: FormGroup;

  private routeSub: Subscription = new Subscription();

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private service: VoucherService) {
    this.commentFormGroup = this.formBuilder.group({
      Content: new FormControl(null),
    });
  }

  ngOnInit(): void {
    this.service.get(this.router.url.split('/').slice(-1)[0]).subscribe((data: VoucherModel) => {
      this.description = data.description;
      this.expirationDate = data.expirationDate.split('T')[0];
      this.name = data.name;
      this.comments = data.comments;
      if (localStorage.getItem('userRole') === 'Student')
      {
        this.isStudent = true;
        this.couponId = this.router.url.split('/').slice(-1)[0];
      }
    });
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
  postComment(): void{
    const data: CommentModel = this.commentFormGroup.getRawValue();
    this.service.postComment(this.router.url.split('/').slice(-1)[0], data).subscribe(() => {
      //TODO: clear comment section and render comment instead of reloading the page
      window.location.reload();
    });
  }
}
