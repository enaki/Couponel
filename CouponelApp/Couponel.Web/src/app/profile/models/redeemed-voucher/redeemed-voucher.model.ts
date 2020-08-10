import {VoucherModel} from '../../../voucher/models/voucher.model';

export type RedeemedVoucherModel = {
  id: string;
  status: string;
  redeemedDate: Date;
  coupon: VoucherModel;
  couponId: string;
};
