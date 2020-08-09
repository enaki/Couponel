import {VoucherModel} from './voucher.model';

export type RedeemedVoucherModel = {
  status: string;
  redeemedDate: string;
  coupon: VoucherModel;
  couponId: string;
};
