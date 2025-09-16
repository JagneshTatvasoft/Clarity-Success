import { Component, Input } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { TableColumn } from '../../../models/table-column.model';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { CommonModule } from '@angular/common';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { FormsModule } from '@angular/forms';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
  selector: 'app-custom-table',
  imports: [
    MatIconModule,
    MatTableModule,
    MatButtonModule,
    MatInputModule,
    MatPaginatorModule,
    CommonModule,
    MatCheckboxModule,
    FormsModule,
  ],
  templateUrl: './custom-table.component.html',
  styleUrl: './custom-table.component.scss',
})
export class CustomTableComponent<T> {
  @Input() dataSource = new MatTableDataSource<T>();
  @Input() columns: TableColumn<T>[] = [];
  @Input() isSelectable: boolean = false;
  @Input() isEditable: boolean = false;
  @Input() collapsed: boolean = false;
  @Input() tableFilter: boolean = false;

  constructor() {
    console.log(this.collapsed);
  }

  selection = new SelectionModel<T>(false);

  get displayedColumns(): TableColumn<T>[] {
    console.log(this.columns.filter((c) => c.visible));
    return this.columns.filter((c) => c.visible);
  }

  get displayedHeader(): string[] {
    if (this.isSelectable)
      return ['select', ...this.columns.filter((c) => c.visible).map((c) => c.key)];

    if (this.isEditable)
      return ['action', ...this.columns.filter((c) => c.visible).map((c) => c.key)];

    return this.columns.filter((c) => c.visible).map((c) => c.key);
  }

  get filterHeader(): string[] {
    // same keys to keep columns aligned
    return this.displayedHeader;
  }
  get selectedItem(): T | null {
    console.log(this.selection.selected[0] ?? null);
    return this.selection.selected[0] ?? null;
  }

  getCellValue(col: TableColumn<T>, row: T): any {
    return col.accessor ? col.accessor(row) : (row as any)[col.key];
  }
}
