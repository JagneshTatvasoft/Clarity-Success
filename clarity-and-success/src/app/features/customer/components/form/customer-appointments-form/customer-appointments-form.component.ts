import { Component } from '@angular/core';
import { CustomTableComponent } from '../../../../../shared/components/custom-table/custom-table.component';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { CustomButtonComponent } from '../../../../../shared/components/custom-button/custom-button.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { MatTableDataSource } from '@angular/material/table';
import { CUSTOMER_APPOINTMENTS, CUSTOMER_CORRESPONDENCE } from '../../../Data/dummyData';
import { TableColumn } from '../../../../../models/table-column.model';
import { CustomerAppointment } from '../../../models/customer-appointment.model';
import { CUSTOMER_APPOINTMENT_TABLE_CONFIG, CUSTOMER_CORRESPONDENCE_TABLE_CONFIG } from '../../../config/table-config';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CustomerCorrespondence } from '../../../models/customer-correspondence.model';

@Component({
  selector: 'app-customer-appointments-form',
  imports: [
    CustomTableComponent,
    MatIconModule,
    MatDialogModule,
    CustomButtonComponent,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatOptionModule,
    MatCheckboxModule,
    CommonModule,
    FormsModule,
  ],
  templateUrl: './customer-appointments-form.component.html',
  styleUrl: './customer-appointments-form.component.scss',
})
export class CustomerAppointmentsFormComponent {
  showPictures = true;

  // appointment data
  appointmnets = new MatTableDataSource(CUSTOMER_APPOINTMENTS);
  columns: TableColumn<CustomerAppointment>[] = CUSTOMER_APPOINTMENT_TABLE_CONFIG;

  // Correspondence data
  correspondence = new MatTableDataSource(CUSTOMER_CORRESPONDENCE);
  corresepondenceColumn: TableColumn<CustomerCorrespondence>[] = CUSTOMER_CORRESPONDENCE_TABLE_CONFIG;

  onExpandChange(event: any) {
    this.showPictures = event.checked;
    console.log('Checkbox value:', event.checked);
    console.log('showPictures:', this.showPictures);
  }
}
