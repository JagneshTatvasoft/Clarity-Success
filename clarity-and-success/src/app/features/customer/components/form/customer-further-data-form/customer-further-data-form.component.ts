import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule, MatPseudoCheckbox } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-customer-further-data-form',
  imports: [
    MatFormFieldModule,
    MatSelectModule,
    MatOptionModule,
    MatInputModule,
    MatIconModule,
    MatCheckboxModule,
    ReactiveFormsModule
  ],
  templateUrl: './customer-further-data-form.component.html',
  styleUrl: './customer-further-data-form.component.scss',
})
export class CustomerFurtherDataFormComponent {
  @Input() group! : FormGroup;
  @Output() addCustomerClicked = new EventEmitter<void>();
  @Output() removeCustomerClicked = new EventEmitter<void>();

  onAddClick() {
    this.addCustomerClicked.emit();
  }
  onCancelClick() {
    this.removeCustomerClicked.emit();
  }
}
