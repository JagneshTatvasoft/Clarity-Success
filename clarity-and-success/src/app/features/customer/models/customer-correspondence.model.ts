export interface CustomerCorrespondence {
  correspondenceID: number;
  correspondenceType: number;
  correspondenceTypeDescription: string;
  idNumber: number;
  idType: number;
  contactPersonID: number;
  contactPersonName: string;
  date: Date;
  addressing: string;
  subject: string;
  areaType: number;
  areaNumber: string;
  dateCreated: Date;
  personnelNumberOfCreator: number;
  dateChanged: Date;
  personnelNumberOfChanger: number;
  creatorName: string;
  changerName: string;
}
