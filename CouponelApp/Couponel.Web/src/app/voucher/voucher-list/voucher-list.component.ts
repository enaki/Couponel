import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';

import {VoucherModel, VouchersModel} from '../models';
import {VoucherService} from '../services/voucher.service';
import {VoucherImageProvider} from '../services/voucher-image-provider';
import {UserService} from '../../shared/services';
import {UserModel} from '../../shared/models/user.model';
import {PageModel} from '../models/page.model';

@Component({
  selector: 'app-voucher-list',
  templateUrl: './voucher-list.component.html',
  styleUrls: ['./voucher-list.component.scss'],
  providers: [VoucherService]
})
export class VoucherListComponent implements OnInit {
  public voucherList: VoucherModel[];
  public pageModel: PageModel;

  public iterablePages: string[] = [];
  public pageIndex: number;

  public currentUser: UserModel;


  constructor(
    private router: Router,
    private service: VoucherService,
    private imageProvider: VoucherImageProvider,
    private userService: UserService) {
    const user = this.userService.getUserDetails();
    if (user == null){
      this.router.navigate(['authentication']);
    }
  }

  public ngOnInit(): void {
    this.userService.token.subscribe(() => {
      this.currentUser = this.userService.getUserDetails();
    });
    this.pageModel = {sortColumn: 'Name', sortType: 0, pageIndex: 1, pageSize: 8};
    this.service.getAllByModel(this.pageModel).subscribe((data: VouchersModel) => {
      const numberOfPages = (data.count / data.pageSize);
      while ( numberOfPages > this.iterablePages.length) {
        this.iterablePages.push('');
        console.log('test');
      }
      this.pageIndex = data.pageIndex;
      this.voucherList = data.results;
    });
  }

  goToVoucher(id: string): void {
    this.router.navigate([`/voucher/details/${id}`]);
  }

  getCategoryImage(category: string): string{
    return this.imageProvider.getCategoryImage(category);
  }
  goToPage(index: number): void {
    this.pageModel.pageIndex = index;
    this.service.getAllByModel(this.pageModel).subscribe((data: VouchersModel) => {
      this.voucherList = data.results;
    });
  }
}

