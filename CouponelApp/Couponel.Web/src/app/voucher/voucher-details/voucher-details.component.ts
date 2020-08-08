import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';

import { VoucherModel } from '../models';
import { CommentModel } from '../models/comment.model';
import { VoucherService } from '../services/voucher.service';

@Component({
  selector: 'app-voucher-details',
  templateUrl: './voucher-details.component.html',
  styleUrls: ['./voucher-details.component.scss'],
  providers: [FormBuilder]
})
export class VoucherDetailsComponent implements OnInit, OnDestroy {
  fileToUpload: any;
  imageUrl: any;

  formGroup: FormGroup;
  isAdmin: boolean;
  isAddMode: boolean;
  photos: Blob[] = [];

  private routeSub: Subscription = new Subscription();
  comments: CommentModel[];

  get description(): string {
    return this.formGroup.get('description').value;
  }

  get name(): string {
    return this.formGroup.get('name').value;
  }

  get category(): string {
    return this.formGroup.get('category').value;
  }

  get expirationDate(): string {
    return this.formGroup.get('expirationDate').value.replace('T', ' ');
  }

  get isFormDisabled(): boolean {
    return this.formGroup.disabled;
  }

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private service: VoucherService) { }

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      id: new FormControl(),
      name: new FormControl(),
      description: new FormControl(),
      expirationDate: new FormControl(),
      private: new FormControl(false)
    });

    if (this.router.url === '/create-voucher') {
      this.isAddMode = true;
    } else {
      // Getting id from url
      this.routeSub = this.activatedRoute.params.subscribe(params => {
        // Getting details for the coupon with the id found
        this.service.get(params.id).subscribe((data: VoucherModel) => {
          console.log(data);
          this.formGroup.patchValue(data);
          console.log('Comments: ' + data.comments);
          this.comments = data.comments;
        });
        this.formGroup.disable();
      });
      this.isAddMode = false;
    }
    this.isAdmin = true;
  }

  ngOnDestroy(): void {
    this.routeSub.unsubscribe();
  }

  startUpdating(): void {
    this.formGroup.enable();
  }

  save(): void {
    if (this.isAddMode) {
      this.service.post(this.formGroup.getRawValue()).subscribe();
      this.router.navigate(['list']);
    } else {
      this.service.patch(this.formGroup.getRawValue()).subscribe();
    }

    this.photos.push(this.imageUrl);
    this.imageUrl = null;
    this.formGroup.disable();
  }

  handleFileInput(file: FileList): void {
    this.fileToUpload = file.item(0);

    const reader = new FileReader();
    reader.onload = (event: any) => {
      this.imageUrl = event.target.result;
    };
    reader.readAsDataURL(this.fileToUpload);
  }
}
