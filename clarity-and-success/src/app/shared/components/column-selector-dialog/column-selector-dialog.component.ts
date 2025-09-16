import { Component, Inject } from '@angular/core';
import { TableColumn } from '../../../models/table-column.model';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-column-selector-dialog',
  imports: [MatDialogModule, MatCheckboxModule, FormsModule],
  templateUrl: './column-selector-dialog.component.html',
  styleUrl: './column-selector-dialog.component.scss',
})
export class ColumnSelectorDialogComponent<T> {
  columns: TableColumn<T>[];

  constructor(
    private dialogRef: MatDialogRef<ColumnSelectorDialogComponent<T>>,
    @Inject(MAT_DIALOG_DATA) public data: { columns: TableColumn<T>[] }
  ) {
    // this.columns = JSON.parse(JSON.stringify(data.columns));
    // Preserve accessor functions
    this.columns = data.columns.map((c) => ({ ...c }));
  }

  save() {
    this.dialogRef.close(this.columns);
  }

  cancel() {
    this.dialogRef.close(null);
  }

  selectAll() {
    this.columns.forEach((c) => (c.visible = true));
  }
  
  deselectAll() {
    this.columns.forEach((c) => (c.visible = false));
  }
}
