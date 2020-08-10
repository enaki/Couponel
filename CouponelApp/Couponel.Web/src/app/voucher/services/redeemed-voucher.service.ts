import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import {RedeemedVoucherModel} from '../models/redeemed-voucher/redeemed-voucher.model';
import {DeleteRedeemedVoucherModel} from '../models/redeemed-voucher/delete.redeemed-voucher.model';

@Injectable({
  providedIn: 'root'
})
export class RedeemedVoucherService {

  private endpoint = 'https://localhost:5001/api/redeemedCoupons';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${JSON.parse(localStorage.getItem('userToken'))}`
    })
  };

  constructor(private readonly http: HttpClient) { }

  get(redeemedCouponId: string): Observable<RedeemedVoucherModel> {
    console.log('Get By Id from Redeemed Service');
    return this.http.get<RedeemedVoucherModel>(`${this.endpoint}/${redeemedCouponId}`, this.httpOptions);
  }

  getAll(): Observable<RedeemedVoucherModel[]> {
    console.log('GetAll from Redeemed Service');
    return this.http.get<RedeemedVoucherModel[]>(this.endpoint, this.httpOptions);
  }

  deleteRedeemedCoupon(redeemedCouponId: string): Observable<unknown>{
    return this.http.delete<unknown>(`${this.endpoint}/${redeemedCouponId}`, this.httpOptions);
  }

  updateRedeemedCoupon(redeemedCouponId: string): Observable<unknown> {
    return this.http.patch<unknown>(`${this.endpoint}/${redeemedCouponId}?newStatus=Used`, this.httpOptions);
  }
}
