import {VoucherModel} from '../voucher.model';

export type RedeemedVoucherModel = {
  id: string;
  status: string;
  redeemedDate: Date;
  coupon: VoucherModel;
  couponId: string;
};
