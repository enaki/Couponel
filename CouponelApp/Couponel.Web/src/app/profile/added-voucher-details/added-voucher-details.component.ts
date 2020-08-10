import {Component, OnDestroy, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {OffererVouchersService} from '../services/offerer-vouchers.service';
import {VoucherImageProvider} from '../../voucher/services/voucher-image-provider';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {VoucherModel} from '../../voucher/models';

@Component({
  selector: 'app-added-voucher-details',
  templateUrl: './added-voucher-details.component.html',
  styleUrls: ['./added-voucher-details.component.scss']
})
export class AddedVoucherDetailsComponent implements OnInit, OnDestroy {
  formGroup: FormGroup;
  constructor(
    private router: Router,
    private service: OffererVouchersService,
    private imageProvider: VoucherImageProvider,
    private formBuilder: FormBuilder) {
    this.service.getVoucher(this.router.url.split('/').slice(-1)[0]).subscribe((data: VoucherModel) => {
      this.formGroup = this.formBuilder.group({
        name: new FormControl(data.name, [Validators.required, Validators.minLength(5)]),
        category: new FormControl(data.category, [Validators.required, Validators.minLength(5),
          Validators.pattern('^(?:Electronics|Fashion|Entertainment|Food|Coffee&Snack|Accessories|Home|Sport|Others|Auto)$')]),
        expirationDate: new FormControl(data.expirationDate, [Validators.required]),
        description: new FormControl(data.description, [Validators.required, Validators.minLength(5)]),
      });
    });
  }
  ngOnInit(): void {
  }
  ngOnDestroy(): void {
  }
  updateVoucher(): void{
    const data: VoucherModel = this.formGroup.getRawValue();
    this.service.updateVoucher(this.router.url.split('/').slice(-1)[0], data).subscribe(() => {
      this.router.navigate(['profile/added-vouchers']);
    });
  }
  deleteVoucher(): void{
    this.service.deleteVoucher(this.router.url.split('/').slice(-1)[0]).subscribe(() => {
      this.router.navigate(['profile/added-vouchers']);
    });
  }
}
