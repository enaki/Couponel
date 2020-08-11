import { Component, OnInit } from '@angular/core';
import {UserService} from '../../shared/services';
import {VoucherService} from '../../voucher/services/voucher.service';
import {RedeemedVoucherService} from '../../profile/services/redeemed-voucher.service';
import {VoucherModel} from '../../voucher/models';
import {RedeemedVoucherDetailsComponent} from '../../profile/redeemed-voucher-details/redeemed-voucher-details.component';
import {RedeemedVoucherModel} from '../../profile/models/redeemed-voucher/redeemed-voucher.model';
import {VoucherStatisticsModel} from '../models/voucher-statistics-model';
import {AdminStatisticsService} from '../services/voucher-statistics.service';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.scss']
})
export class StatisticsComponent implements OnInit {
  private voucherList: VoucherModel[];
  private redeemedVoucherList: RedeemedVoucherModel[];
  public redeemedVoucherStatistics: VoucherStatisticsModel;
  public voucherStatistics: VoucherStatisticsModel;

  constructor(
    private readonly userService: UserService,
    private readonly voucherService: VoucherService,
    private readonly adminService: AdminStatisticsService,
    private readonly redeeemedVoucherService: RedeemedVoucherService,
  ) {
    this.voucherService.getAll().subscribe((vouchersData) => {
      console.log(vouchersData);
      this.voucherList = vouchersData.results;
      this.voucherStatistics = this.adminService.getVouchersStatistics(this.voucherList);
      this.redeeemedVoucherService.getAllByAdmin().subscribe((redVouchersData) => {
        this.redeemedVoucherList = redVouchersData;
        this.redeemedVoucherStatistics = this.adminService.getRedeemedVouchersStatistics(this.redeemedVoucherList, this.voucherList);
        console.log(redVouchersData);
      });
    });
  }

  ngOnInit(): void {

  }

}
