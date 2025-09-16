import { Routes } from '@angular/router';
import { CustomerPageComponent } from './components/customer-page/customer-page.component';
import { CustomerDetailsPageComponent } from './containers/customer-details-page/customer-details-page.component';
import { CustomerListPageComponent } from './containers/customer-list-page/customer-list-page.component';
import { CustomerSearchPageComponent } from './containers/customer-search-page/customer-search-page.component';

export const CUSTOMER_ROUTES: Routes = [
  {
    path: '',
    component: CustomerPageComponent,
    children: [
      {
        path: '',
        redirectTo: 'details',
        pathMatch: 'full', // 👈 Default load CustomerDetails
      },
      {
        path: 'details',
        component: CustomerDetailsPageComponent,
      },
      {
        path: 'list',
        component: CustomerListPageComponent,
      },
      {
        path: 'search',
        component: CustomerSearchPageComponent,
      },
    ],
  },
];
