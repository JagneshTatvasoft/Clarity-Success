import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { CUSTOMER_DETAILS } from '../../../Data/dummyData';
import { CustomerDetails } from '../../../models/customer-details.model';
import { TableColumn } from '../../../../../models/table-column.model';
import { CUSTOMER_COLUMNS } from '../../../config/table-config';
import { CustomTableComponent } from '../../../../../shared/components/custom-table/custom-table.component';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { CustomButtonComponent } from '../../../../../shared/components/custom-button/custom-button.component';
import { ColumnSelectorDialogComponent } from '../../../../../shared/components/column-selector-dialog/column-selector-dialog.component';

@Component({
  selector: 'app-contact-person-form',
  imports: [
    CustomTableComponent,
    MatIconModule,
    MatDialogModule,
    CustomButtonComponent,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatOptionModule,
  ],
  templateUrl: './contact-person-form.component.html',
  styleUrl: './contact-person-form.component.scss',
})
export class ContactPersonFormComponent {
  customer = new MatTableDataSource(CUSTOMER_DETAILS);
  columns: TableColumn<CustomerDetails>[] = CUSTOMER_COLUMNS;

  constructor(private dialog: MatDialog) {}

  openColumnSelector() {
    const dialogRef = this.dialog.open(ColumnSelectorDialogComponent, {
      width: '500px',
      height: '400px',
      data: { columns: this.columns },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.columns = result;
      }
    });
  }
}
