import { Component, OnInit } from '@angular/core';
import {UserService} from '../../shared/services';
import {VoucherService} from '../../voucher/services/voucher.service';
import {RedeemedVoucherService} from '../../profile/services/redeemed-voucher.service';
import {VoucherModel} from '../../voucher/models';
import {RedeemedVoucherModel} from '../../profile/models/redeemed-voucher/redeemed-voucher.model';
import {VoucherStatisticsModel} from '../models/voucher-statistics-model';
import {AdminStatisticsService} from '../services/voucher-statistics.service';
import {StatisticsUserModel} from '../models/statistics-user.model';
import {Router} from '@angular/router';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.scss']
})
export class StatisticsComponent implements OnInit {
  private voucherList: VoucherModel[];
  private redeemedVoucherList: RedeemedVoucherModel[];
  public usersList: StatisticsUserModel[];
  public redeemedVoucherStatistics: VoucherStatisticsModel;
  public voucherStatistics: VoucherStatisticsModel;
  public userRole: string;
  constructor(
    private readonly userService: UserService,
    private readonly voucherService: VoucherService,
    private readonly adminService: AdminStatisticsService,
    private readonly redeemedVoucherService: RedeemedVoucherService,
    private readonly router: Router,
  ) {
    const user = this.userService.getUserDetails();
    if (user == null){
      this.router.navigate(['authentication']);
    }
    this.userService.token.subscribe(() => {
      this.userRole = this.userService.getUserDetails().role;
    });
    this.voucherService.getAll().subscribe((vouchersData) => {
      console.log(vouchersData);
      this.voucherList = vouchersData.results;
      this.voucherStatistics = this.adminService.getVouchersStatistics(this.voucherList);
      this.redeemedVoucherService.getAllByAdmin().subscribe((redVouchersData) => {
        this.redeemedVoucherList = redVouchersData;
        this.redeemedVoucherStatistics = this.adminService.getRedeemedVouchersStatistics(this.redeemedVoucherList, this.voucherList);
        console.log(redVouchersData);
      });
    });
    this.adminService.getAllUsers().subscribe((users) => {
      this.usersList = users;
      console.log(users);
    });
  }

  ngOnInit(): void {
  }

}
