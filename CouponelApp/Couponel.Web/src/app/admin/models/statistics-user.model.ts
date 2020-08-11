import {AddressModel} from '../../profile/models/address.model';

export type StatisticsUserModel = {
  userId: string;
  userName: string;
  email: string;
  firstName: string;
  lastName: string;
  phoneNumber: string;
  role: string;
  address: AddressModel
};
