import { AddressModel } from './address.model';

export type UpdateProfileInfoModel = {
  email: string;
  firstName: string;
  lastName: string;
  password: string;
  confirmPassword: string;
  phoneNumber: string;
  address: AddressModel;
};
