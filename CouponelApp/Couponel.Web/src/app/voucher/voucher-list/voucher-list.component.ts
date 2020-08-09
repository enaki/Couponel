import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { VoucherModel, VouchersModel } from '../models';
import { VoucherService } from '../services/voucher.service';

@Component({
  selector: 'app-voucher-list',
  templateUrl: './voucher-list.component.html',
  styleUrls: ['./voucher-list.component.scss'],
  providers: [VoucherService]
})
export class VoucherListComponent implements OnInit {
  public voucherList: VoucherModel[];
  private categoryImages =
  {
    "Restaurant":"../../assets/images/restaurant.svg",
    "Auto":"../../assets/images/auto.svg",
    "Electronics":"../../assets/images/electronics.svg",
    "Coffee":"../../assets/images/coffee.svg",
    "Entertainment":"../../assets/images/entertainment.svg",
    "Fashion":"../../assets/images/fashion.svg",
    "Accessories":"../../assets/images/accessories.svg",
    "Supplies":"../../assets/images/supplies.svg",
    "Sport":"../../assets/images/sport.svg",
    "Others":"../../assets/images/others.svg"
  };
  constructor(
    private router: Router,
    private service: VoucherService) { }

  public ngOnInit(): void {
    this.service.getAll().subscribe((data: VouchersModel) => {
      console.log(data.results);
      this.voucherList = data.results;
    });
  }

  goToVoucher(id: string): void {
    this.router.navigate([`/voucher/details/${id}`]);
  }

  getCategoryImage(category: string): string{
    let result = this.categoryImages[category];
    if(result == null)
    {
      return "../../assets/images/coupon.png";
    }
    return result;
  }
}

