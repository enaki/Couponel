import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { VoucherModel } from '../models';
import { CommentModel } from '../models/comment.model';
import { VoucherService } from '../services/voucher.service';
import {UserService} from '../../shared/services';
import {CreateRedeemedVoucherModel} from '../../profile/models/redeemed-voucher/create.redeemed-voucher.model';
import {CreateCommentModel} from "../models/create.comment.model";
import {RegisterModel} from "../../authentication/models/register.model";
import {TokenService} from '../../shared/services/token.service';


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
    private userService: UserService,
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
      if (this.userService.getUserDetails().userRole === 'Student')
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
    const redeemedCouponData: CreateRedeemedVoucherModel = {
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
