import { Routes } from '@angular/router';
import { MainLayoutComponent } from './core/layouts/main-layout/main-layout.component';

export const routes: Routes = [
  //   {
  //     path: '',
  //     redirectTo: 'auth/login',
  //     pathMatch: 'full',
  //   },
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      {
        path: 'customer',
        loadChildren: () =>
          import('./features/customer/customer.routes').then((m) => m.CUSTOMER_ROUTES),
      },
    ],
  },
//   {
//     path: 'auth',
//     component: AuthLayoutComponent,
//     children: [
//       {
//         path: 'login',
//         loadComponent: () =>
//           import('./features/auth/login/login.component').then((m) => m.LoginComponent),
//       },
//       {
//         path: 'register',
//         loadComponent: () =>
//           import('./features/auth/register/register.component').then((m) => m.RegisterComponent),
//       },
//     ],
//   },
//   {
//     path: '**',
//     redirectTo: 'auth/login',
//   },
];
