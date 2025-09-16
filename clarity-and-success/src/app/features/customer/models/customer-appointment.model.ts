export interface CustomerAppointment {
    customerIdL?: number,
  appointmentID?: number;
  appointmentEventID?: number;
  event: string;
  date: Date;
  note: string;
  autoDelete: boolean;
  itemNoVendor: string;
  employeeNumber: number;
  employeeSalutation: string;
  employeeName: string;
  contactPersonPosition: string;
  isDeleted: boolean;
  contactPersonFirstName: string;
  contactPersonLastName: string;
  productGroup: string;
  articleType: string;
  description: string;
  sellingPrice1: number;
}
