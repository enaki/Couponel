import { AddressModel } from './address.model';

export type ProfileInfoModel = {
  userName: string;
  email: string;
  firstName: string;
  lastName: string;
  phoneNumber: string;
  facultyName: string;
  universityName: string;
  address: AddressModel;
};
