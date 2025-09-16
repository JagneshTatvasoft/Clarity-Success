export interface CustomerPrice {
  customerNumber: number;
  deliveryItemNumber: number;
  specialPrice: number;
  specialDiscount: number;
  isVAT: boolean;
  image?: string;
  supplierArticleNumber: string;
  referenceNumber: string;
  longDescription: string;
  rp1: number;
}
