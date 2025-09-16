import { Component, Input } from '@angular/core';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { CustomButtonComponent } from '../../../../../shared/components/custom-button/custom-button.component';
import { CustomTableComponent } from '../../../../../shared/components/custom-table/custom-table.component';
import { CUSTOMER_BILLING_ADDRESSES, CUSTOMER_PRICES } from '../../../Data/dummyData';
import { CUSTOMER_BILLING_ADDRESSES_TABLE_CONFIG, CUSTOMER_PRICES_TABLE_CONFIG } from '../../../config/table-config';
import { CustomerBillingAddress } from '../../../models/customer-billing-address.model';
import { TableColumn } from '../../../../../models/table-column.model';
import { MatTableDataSource } from '@angular/material/table';
import { CustomerPrice } from '../../../models/customer-price.model';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-customer-addresses-form',
  imports: [
    MatFormFieldModule,
    MatSelectModule,
    MatOptionModule,
    MatInputModule,
    MatIconModule,
    MatCheckboxModule,
    CustomButtonComponent,
    CustomTableComponent,
    ReactiveFormsModule
  ],
  templateUrl: './customer-addresses-form.component.html',
  styleUrl: './customer-addresses-form.component.scss',
})
export class CustomerAddressesFormComponent {
  @Input() group! : FormGroup;

  billingAddress = new MatTableDataSource(CUSTOMER_BILLING_ADDRESSES);
  columns: TableColumn<CustomerBillingAddress>[] = CUSTOMER_BILLING_ADDRESSES_TABLE_CONFIG;

  customerPricing = new MatTableDataSource(CUSTOMER_PRICES);
  customerPricingColumns: TableColumn<CustomerPrice>[] = CUSTOMER_PRICES_TABLE_CONFIG;
}
