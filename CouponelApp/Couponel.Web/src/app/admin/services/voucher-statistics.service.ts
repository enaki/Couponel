import { HttpClient } from '@angular/common/http';
import {Injectable} from '@angular/core';
import { Observable } from 'rxjs';

import {UserService} from '../../shared/services';
import {VoucherStatisticsModel} from '../models/voucher-statistics-model';
import {VoucherModel} from '../../voucher/models';
import {RedeemedVoucherModel} from '../../profile/models/redeemed-voucher/redeemed-voucher.model';

@Injectable({
  providedIn: 'root'
})
export class AdminStatisticsService {

  private httpOptions: unknown;

  constructor(private readonly http: HttpClient, private userService: UserService) {
    this.userService.token.subscribe((token) => {
      console.log('Vouchers Details' + token);
      this.httpOptions = this.userService.getHttpOptions();
    });
  }

  public getVouchersStatistics(voucherList: VoucherModel[]): VoucherStatisticsModel {
    const processedData: VoucherStatisticsModel = new VoucherStatisticsModel();
    for (let i = 0; i < voucherList.length; i++) {
      switch (voucherList[i].category) {
        case 'Electronics':
          processedData.Electronics++;
          break;
        case 'Fashion':
          processedData.Fashion++;
          break;
        case 'Entertainment':
          processedData.Entertainment++;
          break;
        case 'Food'  :
          processedData.Food++;
          break;
        case 'Coffee&Snacks':
          processedData.CoffeeAndSnacks++;
          break;
        case 'Accessories':
          processedData.Accessories++;
          break;
        case 'Home':
          processedData.Home++;
          break;
        case 'Sport':
          processedData.Sport++;
          break;
        case 'Others':
          processedData.Others++;
          break;
        case 'Auto':
          processedData.Auto++;
          break;
      }
    }
    console.log(processedData);
    return processedData;
  }

  getRedeemedVouchersStatistics(redeemedVoucherList: RedeemedVoucherModel[], voucherList: VoucherModel[]): VoucherStatisticsModel {
    const processedData: VoucherStatisticsModel = new VoucherStatisticsModel();
    for (let i = 0; i < redeemedVoucherList.length; i++) {
      const filteredCoupons = voucherList.filter(coupon => coupon.id === redeemedVoucherList[i].couponId);
      if (filteredCoupons.length === 0) {
        continue;
      }
      switch (filteredCoupons[0].category) {
        case 'Electronics':
          processedData.Electronics++;
          break;
        case 'Fashion':
          processedData.Fashion++;
          break;
        case 'Entertainment':
          processedData.Entertainment++;
          break;
        case 'Food'  :
          processedData.Food++;
          break;
        case 'Coffee&Snacks':
          processedData.CoffeeAndSnacks++;
          break;
        case 'Accessories':
          processedData.Accessories++;
          break;
        case 'Home':
          processedData.Home++;
          break;
        case 'Sport':
          processedData.Sport++;
          break;
        case 'Others':
          processedData.Others++;
          break;
        case 'Auto':
          processedData.Auto++;
          break;
      }
    }
    return processedData;
  }
}
