import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { MatMenuModule } from '@angular/material/menu';

@Component({
  selector: 'app-custom-sidenav',
  imports: [MatIconModule, CommonModule, RouterModule, MatMenuModule],
  templateUrl: './custom-sidenav.component.html',
  styleUrl: './custom-sidenav.component.scss',
})
export class CustomSidenavComponent {
  @Input() label!: string;
  @Input() icon?: string;
  @Input() link?: string;
  @Input() image?: string;
  @Input() expandable = false;
  @Input() expanded = false;
  @Input() menu?: any[] = [];

  @Output() toggleExpand = new EventEmitter<void>();

  constructor() {
    console.log(this.menu);
  }

  onNodeClick(event: MouseEvent) {
    debugger
    if (this.expandable) {
      this.toggleExpand.emit();
    } else if (this.menu && this.menu.length > 0) {
      console.log("this is " + this.menu)
      event.stopPropagation();
    }
  }
}
