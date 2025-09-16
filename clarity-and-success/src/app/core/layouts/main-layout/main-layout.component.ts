import { Component, inject, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MediaMatcher } from '@angular/cdk/layout';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';

import { MatTreeModule } from '@angular/material/tree';
import { CustomSidenavComponent } from '../../../shared/components/custom-sidenav/custom-sidenav.component';

@Component({
  selector: 'app-main-layout',
  imports: [
    CommonModule,
    RouterOutlet,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatSidenavModule,
    MatListModule,
    MatTreeModule,
    CustomSidenavComponent,
  ],
  templateUrl: './main-layout.component.html',
  styleUrl: './main-layout.component.scss',
})
export class MainLayoutComponent {
  appTitle = 'Employee Management';
  activeTab = 'employees';

  navItems = [
    {
      label: 'Sales',
      image: 'finance',
      children: [
        { label: 'Till', link: '/sales/till' },
        {
          label: 'Other',
          menu: [
            { label: 'Voucher Management', link: '/sales/voucher-management' },
            { label: 'Deposit Management', link: '/sales/deposit-management' },
            { label: 'Reservation Management', link: '/sales/reservation-management' },
            { label: 'Instalment Management', link: '/sales/instalment-management' },
            { label: 'Bank Transfer Management', link: '/sales/bank-transfer-management' },
            { label: 'Precious Metal Purchase', link: '/sales/precious-metal-purchase' },
            { label: 'Sales Order Management', link: '/sales/sales-order-management' },
            { label: 'Goods on Approval to Customer/Branch', link: '/sales/goods-approval' },
            { label: 'Order Management - Backlogs', link: '/sales/order-management-backlogs' },
            {
              label: 'Order Management - Branch Distribution',
              link: '/sales/order-management-branch-distribution',
            },
            { label: 'Count Cash', link: '/sales/count-cash' },
            { label: 'Till Expenses', link: '/sales/till-expenses' },
            { label: 'Till Closing', link: '/sales/till-closing' },
            { label: 'Cashbook', link: '/sales/cashbook' },
            { label: 'End of Day Overview', link: '/sales/end-of-day-overview' },
            { label: 'Till Drawer Openings', link: '/sales/till-drawer-openings' },
            { label: 'Search Sales', link: '/sales/search-sales' },
          ],
        },
      ],
    },
    { label: 'Articles', image: 'articles', link: '/articles' },
    { label: 'Repairs', image: 'repairs', link: '/repairs' },
    { label: 'Purchases', image: 'customer', link: '/purchases' },
    { label: 'Customers', image: 'customer', link: '/customer' },
    { label: 'Suppliers', image: 'suppliers', link: '/suppliers' },
    { label: 'Employees', image: 'employees', link: '/employees' },
    { label: 'Pawnbroking', image: 'employees', link: '/employees' },
    { label: 'Statistics', image: 'customer', link: '/statistics' },
    { label: 'Tools', image: 'customer', link: '/statistics' },
  ];

  childrenAccessor = (node: any) => node.children ?? [];
  hasChild = (_: number, node: any) => !!node.children && node.children.length > 0;
  hasMenu = (_: number, node: any) => !!node.menu && node.menu.length > 0;

  protected readonly fillerNav = Array.from({ length: 10 }, (_, i) => `Nav Item ${i + 1}`);

  protected readonly isMobile = signal(true);

  private readonly _mobileQuery: MediaQueryList;
  private readonly _mobileQueryListener: () => void;

  constructor() {
    const media = inject(MediaMatcher);

    this._mobileQuery = media.matchMedia('(max-width: 992px)');
    this.isMobile.set(this._mobileQuery.matches);
    this._mobileQueryListener = () => this.isMobile.set(this._mobileQuery.matches);
    this._mobileQuery.addEventListener('change', this._mobileQueryListener);
  }

  ngOnDestroy(): void {
    this._mobileQuery.removeEventListener('change', this._mobileQueryListener);
  }

  protected readonly shouldRun = /(^|.)(stackblitz|webcontainer).(io|com)$/.test(
    window.location.host
  );
}
