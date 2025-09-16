import { Component, Input } from '@angular/core';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import {MatRadioModule} from '@angular/material/radio';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-customer-further-data2-form',
  imports: [
    MatFormFieldModule,
    MatSelectModule,
    MatOptionModule,
    MatInputModule,
    MatIconModule,
    MatCheckboxModule,
    MatRadioModule,
    ReactiveFormsModule
  ],
  templateUrl: './customer-further-data2-form.component.html',
  styleUrl: './customer-further-data2-form.component.scss'
})
export class CustomerFurtherData2FormComponent {
  @Input() group! : FormGroup;
}
