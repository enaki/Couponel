import { VoucherModel } from './voucher.model';

export type VouchersModel = {
  count: number;
  pageIndex: number;
  pageSize: number;
  results: VoucherModel[];
};
