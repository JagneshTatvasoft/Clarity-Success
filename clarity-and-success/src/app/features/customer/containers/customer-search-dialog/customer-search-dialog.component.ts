import { Component, signal, Signal } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { CUSTOMER_DETAILS } from '../../Data/dummyData';
import { TableColumn } from '../../../../models/table-column.model';
import { CustomerDetails } from '../../models/customer-details.model';
import { CUSTOMER_COLUMNS } from '../../config/table-config';
import { CustomTableComponent } from '../../../../shared/components/custom-table/custom-table.component';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { CustomButtonComponent } from '../../../../shared/components/custom-button/custom-button.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ColumnSelectorDialogComponent } from '../../../../shared/components/column-selector-dialog/column-selector-dialog.component';

@Component({
  selector: 'app-customer-search-dialog',
  imports: [
    CustomTableComponent,
    MatIconModule,
    MatDialogModule,
    CustomButtonComponent,
    MatFormFieldModule,
    MatInputModule,
  ],
  templateUrl: './customer-search-dialog.component.html',
  styleUrl: './customer-search-dialog.component.scss',
})
export class CustomerSearchDialogComponent {
  customer = new MatTableDataSource(CUSTOMER_DETAILS);
  columns = signal<TableColumn<CustomerDetails>[]>(CUSTOMER_COLUMNS);

  constructor(private dialog: MatDialog) {}

  openColumnSelector() {
    const dialogRef = this.dialog.open(ColumnSelectorDialogComponent, {
      width: '500px',
      height: '400px',
      data: { columns: this.columns() },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.columns.set(result);
      }
    });
  }
}
