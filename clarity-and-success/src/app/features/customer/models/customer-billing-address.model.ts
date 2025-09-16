export interface CustomerBillingAddress {
  customerNumber: number;
  customerNoOfAddress: number;
  // in db addressType is int and refrence to it's table name
  addressType: string;
  remark: string;
  company: string;
  title: string;
  firstName: string;
  surname: string;
  street: string;
  country: string;
  postcodeCity: string;
  county: string;
  addressInfo: string;
}
