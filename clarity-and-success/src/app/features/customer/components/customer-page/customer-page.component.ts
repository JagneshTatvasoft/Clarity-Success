import { Component } from '@angular/core';
import { CustomButtonComponent } from '../../../../shared/components/custom-button/custom-button.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { RouterModule } from '@angular/router';
import { MatTabsModule } from '@angular/material/tabs';

@Component({
  selector: 'app-customer-page',
  imports: [CustomButtonComponent, MatGridListModule, RouterModule, MatTabsModule, RouterModule],
  templateUrl: './customer-page.component.html',
  styleUrl: './customer-page.component.scss',
})
export class CustomerPageComponent {
  // Tab labels
  links = [
    { label: 'Customer Details', path: 'details' },
    { label: 'Customer List', path: 'list' },
    { label: 'Customer Search', path: 'search' },
  ];

}
