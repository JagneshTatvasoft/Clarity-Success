import { Component } from '@angular/core';
import { CustomTableComponent } from '../../../../shared/components/custom-table/custom-table.component';
import { CustomerDetails } from '../../models/customer-details.model';
import { CUSTOMER_DETAILS } from '../../Data/dummyData';
import { TableColumn } from '../../../../models/table-column.model';
import { CUSTOMER_COLUMNS } from '../../config/table-config';
import { MatTableDataSource } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { CustomButtonComponent } from '../../../../shared/components/custom-button/custom-button.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';

@Component({
  selector: 'app-customer-list-page',
  imports: [
    CustomTableComponent,
    MatIconModule,
    MatDialogModule,
    CustomButtonComponent,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatOptionModule
  ],
  templateUrl: './customer-list-page.component.html',
  styleUrl: './customer-list-page.component.scss',
})
export class CustomerListPageComponent {
  customer = new MatTableDataSource(CUSTOMER_DETAILS);
  columns: TableColumn<CustomerDetails>[] = CUSTOMER_COLUMNS;
}
