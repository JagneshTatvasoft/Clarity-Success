import { TableColumn } from '../../../models/table-column.model';
import { CustomerAppointment } from '../models/customer-appointment.model';
import { CustomerBillingAddress } from '../models/customer-billing-address.model';
import { CustomerCorrespondence } from '../models/customer-correspondence.model';
import { CustomerDetails } from '../models/customer-details.model';
import { CustomerPrice } from '../models/customer-price.model';

/**
 * Table column configuration for Customer table
 */
export const CUSTOMER_COLUMNS: TableColumn<CustomerDetails>[] = [
  {
    key: 'customerNo',
    label: 'Customer No.',
    visible: true,
    accessor: (row) => row.basicInfo.customerNo,
  },
  {
    key: 'branch',
    label: 'Branch No.',
    visible: true,
    accessor: (row) => row.basicInfo.branch,
  },
  {
    key: 'ownNo',
    label: 'Own No',
    visible: false,
    accessor: (row) => row.basicInfo.ownNo,
  },
  {
    key: 'company',
    label: 'Company',
    visible: true,
    accessor: (row) => row.basicInfo.company,
  },
  {
    key: 'salutation',
    label: 'Salutation',
    visible: true,
    accessor: (row) => row.basicInfo.salutation,
  },
  {
    key: 'title',
    label: 'Title',
    visible: true,
    accessor: (row) => row.basicInfo.title,
  },
  {
    key: 'firstName',
    label: 'First Name',
    visible: true,
    accessor: (row) => row.basicInfo.firstName,
  },
  {
    key: 'surname',
    label: 'Surname',
    visible: true,
    accessor: (row) => row.basicInfo.surname,
  },
  {
    key: 'streetNo',
    label: 'Street/No.',
    visible: true,
    accessor: (row) => row.basicInfo.streetNo,
  },
  {
    key: 'addressInfo',
    label: 'Address Info',
    visible: true,
    accessor: (row) => row.basicInfo.addressInfo,
  },
  {
    key: 'postcode',
    label: 'Postcode',
    visible: true,
    accessor: (row) => row.basicInfo.postcode,
  },
  {
    key: 'city',
    label: 'City',
    visible: false,
    accessor: (row) => row.basicInfo.city,
  },
  {
    key: 'country',
    label: 'Country',
    visible: false,
    accessor: (row) => row.basicInfo.country,
  },
  {
    key: 'telephone1',
    label: 'Telephone1',
    visible: false,
    accessor: (row) => row.basicInfo.telephone1,
  },
  {
    key: 'telephone2',
    label: 'Telephone2',
    visible: false,
    accessor: (row) => row.basicInfo.telephone2,
  },
  {
    key: 'fax',
    label: 'Fax',
    visible: false,
    accessor: (row) => row.basicInfo.fax,
  },
  {
    key: 'mobile',
    label: 'Mobile',
    visible: false,
    accessor: (row) => row.basicInfo.mobile,
  },
  {
    key: 'email',
    label: 'Email',
    visible: true,
    accessor: (row) => row.basicInfo.email,
  },
  {
    key: 'socialNetwork1',
    label: 'Social Network1',
    visible: true,
    accessor: (row) => row.basicInfo.socialNetwork1,
  },
  {
    key: 'socialNetwork2',
    label: 'Social Network2',
    visible: true,
    accessor: (row) => row.basicInfo.socialNetwork2,
  },
  {
    key: 'website',
    label: 'Website',
    visible: true,
    accessor: (row) => row.basicInfo.website,
  },
  {
    key: 'dateOfBirth',
    label: 'Date Of Birth',
    visible: true,
    accessor: (row) => row.basicInfo.website,
  },
  {
    key: 'age',
    label: 'Age',
    visible: true,
    accessor: (row) => row.basicInfo.age,
  },
  {
    key: 'category1',
    label: 'Category1',
    visible: true,
    accessor: (row) => row.furtherData1.category1,
  },
  {
    key: 'category2',
    label: 'Category2',
    visible: true,
    accessor: (row) => row.furtherData1.category2,
  },
  {
    key: 'category3',
    label: 'Category3',
    visible: true,
    accessor: (row) => row.furtherData1.category3,
  },
  {
    key: 'category4',
    label: 'Category4',
    visible: true,
    accessor: (row) => row.furtherData1.category4,
  },
  {
    key: 'category5',
    label: 'Category5',
    visible: true,
    accessor: (row) => row.furtherData1.category5,
  },
  {
    key: 'category6',
    label: 'Category6',
    visible: true,
    accessor: (row) => row.furtherData1.category6,
  },
  {
    key: 'category7',
    label: 'Category7',
    visible: true,
    accessor: (row) => row.furtherData1.category7,
  },
  {
    key: 'category8',
    label: 'Category8',
    visible: true,
    accessor: (row) => row.furtherData1.category8,
  },
  {
    key: 'category9',
    label: 'Category9',
    visible: true,
    accessor: (row) => row.furtherData1.category9,
  },
  {
    key: 'category10',
    label: 'Category10',
    visible: true,
    accessor: (row) => row.furtherData1.category10,
  },
  {
    key: 'profession',
    label: 'Profession',
    visible: true,
    accessor: (row) => row.furtherData1.profession,
  },
  {
    key: 'hobby',
    label: 'Hobby',
    visible: false,
    accessor: (row) => row.furtherData1.hobby,
  },
  {
    key: 'customerCardType',
    label: 'Card Type',
    visible: false,
    accessor: (row) => row.furtherData1.customerCardType,
  },
  {
    key: 'customerCardNo',
    label: 'Card No',
    visible: false,
    accessor: (row) => row.furtherData1.customerCardNo,
  },
];

/**
 * Table column configuration for Customer Appointment table
 */
export const CUSTOMER_APPOINTMENT_TABLE_CONFIG: TableColumn<CustomerAppointment>[] = [
  {
    key: 'date',
    label: 'Date',
    visible: true,
    accessor: (row) => row.date,
  },
  {
    key: 'employeeName',
    label: 'Appointment With',
    visible: true,
    accessor: (row) => row.employeeName,
  },
  {
    key: 'event',
    label: 'Event',
    visible: true,
    accessor: (row) => row.event,
  },
  {
    key: 'employeeSalutation',
    label: 'Salutation',
    visible: true,
    accessor: (row) => row.employeeSalutation,
  },
  {
    key: 'contactPersonFirstName',
    label: 'First Name',
    visible: true,
    accessor: (row) => row.contactPersonFirstName,
  },
  {
    key: 'contactPersonLastName',
    label: 'Last Name',
    visible: true,
    accessor: (row) => row.contactPersonLastName,
  },
  {
    key: 'contactPersonPosition',
    label: 'Position',
    visible: true,
    accessor: (row) => row.contactPersonPosition,
  },
  // comment is reamaning
  {
    key: 'itemNoVendor',
    label: 'Art. No. Suppl.',
    visible: true,
    accessor: (row) => row.itemNoVendor,
  },
  {
    key: 'description',
    label: 'Description',
    visible: true,
    accessor: (row) => row.description,
  },
  // Actually it should be SP1
  {
    key: 'sellingPrice1',
    label: 'RP1',
    visible: false,
    accessor: (row) => row.sellingPrice1,
  },
  // {
  //   key: 'note',
  //   label: 'Note',
  //   visible: false,
  //   accessor: (row) => row.note,
  // },
  // {
  //   key: 'productGroup',
  //   label: 'Artical group',
  //   visible: false,
  //   accessor: (row) => row.productGroup,
  // },
  {
    key: 'isDeleted',
    label: 'IsDeleted',
    visible: false,
    accessor: (row) => row.isDeleted,
  },
];

/**
 * Table column configuration for Customer Correspondence table
 */
export const CUSTOMER_CORRESPONDENCE_TABLE_CONFIG: TableColumn<CustomerCorrespondence>[] = [
  {
    key: 'correspondenceTypeDescription',
    label: 'Type',
    visible: true,
    accessor: (row) => row.correspondenceTypeDescription,
  },
  {
    key: 'date',
    label: 'Date Contact',
    visible: true,
    accessor: (row) => row.date,
  },
  {
    key: 'subject',
    label: 'Topic',
    visible: true,
    accessor: (row) => row.subject,
  },
  {
    key: 'contactPersonName',
    label: 'Contact person',
    visible: true,
    accessor: (row) => row.contactPersonName,
  },
  {
    key: 'personCreated',
    label: 'Created by',
    visible: true,
    accessor: (row) => row.creatorName,
  },
  {
    key: 'personChanged',
    label: 'Changed by',
    visible: true,
    accessor: (row) => row.changerName,
  },
];

/**
 * Table column configuration for Customer Billing Adderess
 */
export const CUSTOMER_BILLING_ADDRESSES_TABLE_CONFIG: TableColumn<CustomerBillingAddress>[] = [
  {
    key: 'customerNumber',
    label: 'Customer No.',
    visible: true,
    accessor: (row: any) => row.customerNoOfAddress,
  },
  {
    key: 'type',
    label: 'Type',
    visible: true,
    accessor: (row: any) => row.addressType,
  },
  {
    key: 'company',
    label: 'Company',
    visible: true,
    accessor: (row: any) => row.company,
  },
  {
    key: 'title',
    label: 'Title',
    visible: true,
    accessor: (row: any) => row.title,
  },
  {
    key: 'firstName',
    label: 'First Name',
    visible: true,
    accessor: (row: any) => row.firstName,
  },
  {
    key: 'surname',
    label: 'Surname',
    visible: true,
    accessor: (row: any) => row.surname,
  },
  {
    key: 'street',
    label: 'Street',
    visible: true,
    accessor: (row: any) => row.street,
  },
  {
    key: 'country',
    label: 'Country',
    visible: true,
    accessor: (row: any) => row.country,
  },
  {
    key: 'postcodeCity',
    label: 'Postcode City',
    visible: true,
    accessor: (row: any) => row.postcodeCity,
  },
  {
    key: 'county',
    label: 'County',
    visible: true,
    accessor: (row: any) => row.county,
  },
  {
    key: 'addressInfo',
    label: 'Address Info',
    visible: true,
    accessor: (row: any) => row.addressInfo,
  },
  {
    key: 'remark',
    label: 'Comment',
    visible: true,
    accessor: (row: any) => row.remark,
  },
];

/**
 * Table column configuration for Customer Prices
 */
export const CUSTOMER_PRICES_TABLE_CONFIG: TableColumn<CustomerPrice>[] = [
  {
    key: 'image',
    label: 'Image',
    visible: true,
    accessor: (row: any) => row.image,
  },
  {
    key: 'supplierArticleNumber',
    label: 'Supplier Article Number',
    visible: true,
    accessor: (row: any) => row.supplierArticleNumber,
  },
  {
    key: 'referenceNumber',
    label: 'Reference Number',
    visible: true,
    accessor: (row: any) => row.referenceNumber,
  },
  {
    key: 'longDescription',
    label: 'Long Description',
    visible: true,
    accessor: (row: any) => row.longDescription,
  },
  {
    key: 'rp1',
    label: 'RP1',
    visible: true,
    accessor: (row: any) => row.rp1,
  },
  {
    key: 'specialPrice',
    label: 'Customer Price',
    visible: true,
    accessor: (row: any) => row.specialPrice,
  },
  {
    key: 'specialDiscount',
    label: 'Discount',
    visible: true,
    accessor: (row: any) => row.specialDiscount,
  },
  {
    key: 'isVAT',
    label: 'Is VAT',
    visible: true,
    accessor: (row: any) => row.isVAT,
  },
];
