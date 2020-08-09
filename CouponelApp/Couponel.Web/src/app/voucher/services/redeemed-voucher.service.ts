import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import {RedeemedVoucherModel} from '../models/redeemed-voucher.model';

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

  getAll(): Observable<RedeemedVoucherModel[]> {
    console.log('GetAll from Redeemed Service');
    return this.http.get<RedeemedVoucherModel[]>(this.endpoint, this.httpOptions);
  }
}
