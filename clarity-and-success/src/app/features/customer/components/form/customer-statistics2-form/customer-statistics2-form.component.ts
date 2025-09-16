import { Component } from '@angular/core';
import { CustomTableComponent } from '../../../../../shared/components/custom-table/custom-table.component';
import { CUSTOMER_SALES_DATA } from '../../../Data/dummyData';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { CustomButtonComponent } from '../../../../../shared/components/custom-button/custom-button.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { MatTableDataSource } from '@angular/material/table';
import { TableColumn } from '../../../../../models/table-column.model';

@Component({
  selector: 'app-customer-statistics2-form',
  imports: [
    MatIconModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatOptionModule,
  ],
  templateUrl: './customer-statistics2-form.component.html',
  styleUrl: './customer-statistics2-form.component.scss',
})
export class CustomerStatistics2FormComponent {
  sales = new MatTableDataSource(CUSTOMER_SALES_DATA);
  // columns: TableColumn<CustomerDetails>[] = CUSTOMER_COLUMNS;

  groupOptions = [
    { key: 'articleGroup', label: 'Article Group' },
    { key: 'articleKind', label: 'Article Kind' },
    { key: 'brand', label: 'Brand' },
    { key: 'productLine', label: 'Product Line' },
    { key: 'collection', label: 'Collection' },
  ];
  selectedGroup = 'brand';

  onGroupChange(groupKey: string) {
   console.log(groupKey);
  }
}
