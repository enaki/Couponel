import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { VoucherModel } from '../models';
import { VouchersModel } from '../models/vouchers.model';

@Injectable({
  providedIn: 'root'
})
export class VoucherService {

  private endpoint: string = 'https://localhost:5001/api/v1/coupons';

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      //'Authorization': `Bearer ${JSON.parse(localStorage.getItem('userToken'))}`
    })
  };

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<VouchersModel> {
    return this.http.get<VouchersModel>(this.endpoint, this.httpOptions);
  }

  get(id: string): Observable<VoucherModel> {
    return this.http.get<VoucherModel>(`${this.endpoint}/${id}`, this.httpOptions);
  }

  post(voucher: VoucherModel): Observable<any> {
    return this.http.post<any>(this.endpoint, voucher, this.httpOptions);
  }

  patch(voucher: VoucherModel): Observable<any> {
    return this.http.patch<any>(`${this.endpoint}/${voucher.id}`, voucher, this.httpOptions);
  }
}
