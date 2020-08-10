import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {UserService} from '../../shared/services';
import {VoucherModel} from '../../voucher/models';
import {OffererCouponsModel} from '../models/voucher/offerer-coupons.model';

@Injectable({
  providedIn: 'root'
})
export class OffererVouchersService {

  private endpoint = 'https://localhost:5001/api/coupons';
  private httpOptions: unknown;

  constructor(private readonly http: HttpClient, private userService: UserService) {
    this.userService.token.subscribe(() => {
      this.httpOptions = this.userService.getHttpOptions();
    });
  }

  getVoucher(voucherId: string): Observable<VoucherModel> {
    console.log('log from service\n\n' + voucherId);
    return this.http.get<VoucherModel>(`${this.endpoint}/${voucherId}`, this.httpOptions);
  }

  getAllVouchers(): Observable<OffererCouponsModel> {
    return this.http.get<OffererCouponsModel>(`${this.endpoint}/offerer-coupons`, this.httpOptions);
  }

  deleteVoucher(voucherId: string): Observable<unknown>{
    return this.http.delete<unknown>(`${this.endpoint}/${voucherId}`, this.httpOptions);
  }

  updateVoucher(voucherId: string, model: VoucherModel): Observable<unknown> {
    const data = {
      "name": model.name,
      "category": model.category,
      "expirationDate": model.expirationDate,
      "description": model.description,
    };
    console.log(data);
    return this.http.patch<unknown>(`${this.endpoint}/${voucherId}`,data, this.httpOptions);
  }
}
