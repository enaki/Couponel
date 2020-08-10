import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Injectable, OnInit} from '@angular/core';
import { Observable } from 'rxjs';

import { VoucherModel } from '../models';
import { PageModel } from '../models/page.model';
import { VouchersModel } from '../models';
import {UserService} from '../../shared/services';

@Injectable({
  providedIn: 'root'
})
export class VoucherService {

  private endpoint = 'https://localhost:5001/api/coupons';
  private redeemedCouponsEndpoint = 'https://localhost:5001/api/redeemedCoupons';
  private httpOptions: unknown;

  constructor(private readonly http: HttpClient, private userService: UserService) {
    this.userService.token.subscribe((token) => {
      console.log('Vouchers Details' + token);
      this.httpOptions = this.userService.getHttpOptions();
    });
  }

  getAll(): Observable<VouchersModel> {
    const data: PageModel =
      {
        sortColumn: 'Name',
        sortType: 0,
        pageIndex: 1,
        pageSize: 100
      };
    return this.http.get<VouchersModel>(`${this.endpoint}?SortColumn=${data.sortColumn}&SortType=${data.sortType}&PageIndex=${data.pageIndex}&PageSize=${data.pageSize}`, this.httpOptions);
  }

  get(id: string): Observable<VoucherModel> {
    return this.http.get<VoucherModel>(`${this.endpoint}/${id}`, this.httpOptions);
  }
  redeemCoupon(couponData: unknown): Observable<unknown> {
    console.log('from service: redeemCoupon');
    console.log(couponData);
    return this.http.post<unknown>(this.redeemedCouponsEndpoint, couponData, this.httpOptions);
  }
  postComment(couponId: string , commentData: unknown): Observable<unknown>{
    return this.http.post<unknown>(`${this.endpoint}/${couponId}/comments`, commentData, this.httpOptions);
  }
  createVoucher(couponData: unknown): Observable<unknown>{
    return this.http.post<unknown>(`${this.endpoint}`, couponData, this.httpOptions);
  }
}
