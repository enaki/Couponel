import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';

import {VoucherModel, VouchersModel} from '../models';
import {VoucherService} from '../services/voucher.service';
import {VoucherImageProvider} from '../services/voucher-image-provider';
import {UserService} from '../../shared/services';
import {UserModel} from '../../shared/models/user.model';

@Component({
  selector: 'app-voucher-list',
  templateUrl: './voucher-list.component.html',
  styleUrls: ['./voucher-list.component.scss'],
  providers: [VoucherService]
})
export class VoucherListComponent implements OnInit {
  public voucherList: VoucherModel[];
  currentUser: UserModel;
  constructor(
    private router: Router,
    private service: VoucherService,
    private imageProvider: VoucherImageProvider,
    private userService: UserService) { }

  public ngOnInit(): void {
    this.userService.token.subscribe(() => {
      this.currentUser = this.userService.getUserDetails();
    });
    this.service.getAll().subscribe((data: VouchersModel) => {
      console.log(data.results);
      this.voucherList = data.results;
    });
  }

  goToVoucher(id: string): void {
    this.router.navigate([`/voucher/details/${id}`]);
  }

  getCategoryImage(category: string): string{
    return this.imageProvider.getCategoryImage(category);
  }
}

