import { Component, inject, signal } from '@angular/core';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatTabsModule } from '@angular/material/tabs';
import { MatDialog } from '@angular/material/dialog';
import { CustomerBasicInfoFormComponent } from '../../components/form/customer-basic-info-form/customer-basic-info-form.component';
import { CustomerFurtherDataFormComponent } from '../../components/form/customer-further-data-form/customer-further-data-form.component';
import { CustomerSearchDialogComponent } from '../customer-search-dialog/customer-search-dialog.component';
import { CustomerFurtherData2FormComponent } from '../../components/form/customer-further-data2-form/customer-further-data2-form.component';
import { ContactPersonFormComponent } from '../../components/form/contact-person-form/contact-person-form.component';
import { RemarkFormComponent } from '../../components/form/remark-form/remark-form.component';
import { CustomerFinancesFormComponent } from '../../components/form/customer-finances-form/customer-finances-form.component';
import { CustomerStatistics1FormComponent } from '../../components/form/customer-statistics1-form/customer-statistics1-form.component';
import { CustomerAppointmentsFormComponent } from '../../components/form/customer-appointments-form/customer-appointments-form.component';
import { CustomerStatistics2FormComponent } from '../../components/form/customer-statistics2-form/customer-statistics2-form.component';
import { CustomerAddressesFormComponent } from '../../components/form/customer-addresses-form/customer-addresses-form.component';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CustomButtonComponent } from '../../../../shared/components/custom-button/custom-button.component';
import { MatIconButton } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-customer-details-page',
  imports: [
    MatExpansionModule,
    MatTabsModule,
    CustomerBasicInfoFormComponent,
    CustomerFurtherDataFormComponent,
    CustomerFurtherData2FormComponent,
    ContactPersonFormComponent,
    RemarkFormComponent,
    CustomerFinancesFormComponent,
    CustomerStatistics1FormComponent,
    CustomerStatistics2FormComponent,
    CustomerAppointmentsFormComponent,
    CustomerAddressesFormComponent,
    ReactiveFormsModule,
    CustomButtonComponent,
    MatIconModule
  ],
  templateUrl: './customer-details-page.component.html',
  styleUrl: './customer-details-page.component.scss',
})
export class CustomerDetailsPageComponent {
  readonly panelOpenState = signal(false);
  private fb = inject(FormBuilder);
  private dialog = inject(MatDialog);

  // Form
  customerDetailsForm = this.fb.group({
    basicInfoForm: this.fb.group({
      customerNo: [{ value: '', disabled: true }],
      ownNo: [''],
      company: [''],
      salutation: [''],
      title: [''],
      firstName: [''],
      surname: [''],
      street: [''],
      addressInfo: [''],
      country: [''],
      postcode: [''],
      city: [''],
      branch: [''],
      telephone1: [''],
      telephone2: [''],
      fax: [''],
      mobile: [''],
      email: [''],
      social1: [''],
      social2: [''],
      website: [''],
      dob: [''],
      age: [''],
    }),
    furtherData1Form: this.fb.group({
      category1: ['', Validators.required],
      category2: ['', Validators.required],
      category3: ['', Validators.required],
      category4: [''],
      category5: [''],
      category6: [''],
      category7: [''],
      category8: [''],
      category9: [''],
      category10: [''],
      profession: ['', Validators.required],
      hobby: [''],
      customerCardType: [''],
      customerCardNo: ['', [Validators.pattern('^[0-9]*$')]],
      referredBy: [''],
      advertising: this.fb.group({
        none: [false],
        mail: [false],
        email: [true],
        sms: [false],
        call: [false],
        dataProtectionDecl: [true],
      }),
    }),
    furtherData2Form: this.fb.group({
      gender: ['', Validators.required],
      placeOfBirth: ['', Validators.required],
      idType: ['', Validators.required],
      idNo: ['', Validators.required],
      issuingAuthority: [''],
      proofOfAddress: [''],
      partner: this.fb.group({
        salutation: [''],
        title: [''],
        firstName: [''],
        surname: [''],
        dob: [''],
        age: [{ value: '', disabled: true }],
      }),
    }),
    editorForm: this.fb.group({
      searchTerm: [''],
      fontSize: [14],
      content: [''],
    }),
    financeForm: this.fb.group({
      accountHolder: ['', Validators.required],
      iban: ['', Validators.required],
      bic: [''],
      bank: [''],
      accountNo: [''],
      sortCode: [''],
      mandateReference: [''],
      mandateDate: [''],
      mandateType: [''],
      paymentCondition: [''],
      deliveryMethod: [''],
      vatId: [''],
      companyNo: [''],
      debtorNo: ['50090'],
      creditorNo: ['10090'],
      vatCurrency: [''],
      discount1: [0],
      discount2: [0],
      creditLimit: [0],
      rpType: [''],
      remind: [false],
      blocked: [false],
      invoiceEmail: [false],
      pledgeBlocked: [false],
      financeComment: [''],
    }),
    addressesForm: this.fb.group({
      fieldService: [''],
      contactPerson: [''],
      specialPrice: [false],
      electronicDeliveryNote: [false],
      languagePrintout: [''],
      languageArticle: [''],
    }),
  });
  //   customerDetailsConfig.forEach((field) => {
  //   if (field.type === 'group' && field.children) {
  //     // Build nested group
  //     const groupControls: Record<string, any> = {};
  //     field.children.forEach((child) => {
  //       groupControls[child.name] = [
  //         child.defaultValue ?? '',
  //         child.validators || [],
  //       ];
  //     });
  //     this.form.addControl(field.name, this.fb.group(groupControls));
  //   } else {
  //     this.form.addControl(
  //       field.name,
  //       this.fb.control(
  //         field.defaultValue ?? '',
  //         field.validators || []
  //       )
  //     );
  //   }
  // });
  basicInfoForm = this.customerDetailsForm.get('basicInfoForm') as FormGroup;
  furtherData1Form = this.customerDetailsForm.get('furtherData1Form') as FormGroup;
  furtherData2Form = this.customerDetailsForm.get('furtherData2Form') as FormGroup;
  editorForm = this.customerDetailsForm.get('editorForm') as FormGroup;
  financeForm = this.customerDetailsForm.get('financeForm') as FormGroup;
  addressesForm = this.customerDetailsForm.get('addressesForm') as FormGroup;
  // Form submit
  SaveCustomerDetailsForm() {
    console.log(this.customerDetailsForm);
  }
  // Open customer search dialog for referred by field in further data 1
  openCustomerSearchDialog() {
    const dialogRef = this.dialog.open(CustomerSearchDialogComponent, {
      width: '800px',
    });

    dialogRef.afterClosed().subscribe((selectedCustomer) => {
      if (selectedCustomer) {
        // store customerId for backend
        console.log('Selected:', selectedCustomer.id, selectedCustomer.name);
      }
    });
  }

  // Remove selected customer for refferrd by field in further data 1
  removeReferredCustomer() {}
}
