import { Component, ElementRef, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { CustomButtonComponent } from '../../../../../shared/components/custom-button/custom-button.component';
import { MatIconModule } from '@angular/material/icon';
import { MatSliderChange, MatSliderModule } from '@angular/material/slider';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-remark-form',
  imports: [
    FormsModule,
    MatFormFieldModule,
    CommonModule,
    MatInputModule,
    MatSliderModule,
    CustomButtonComponent,
    MatIconModule,
    ReactiveFormsModule,
  ],
  templateUrl: './remark-form.component.html',
  styleUrl: './remark-form.component.scss',
})
export class RemarkFormComponent {
  @Input() group!: FormGroup;
  fontSize = 14;
  searchTerm = '';
  private currentIndex = 0;
  private matches: HTMLElement[] = [];

  @ViewChild('editableContent') editableContent!: ElementRef<HTMLDivElement>;

  applyFontSize() {
    const selection = window.getSelection();
    if (!selection || selection.rangeCount === 0) return;

    const range = selection.getRangeAt(0);

    if (!range.collapsed) {
      // Wrap selected text in a <span> with font-size style
      const span = document.createElement('span');
      span.style.fontSize = `${this.fontSize}px`;
      range.surroundContents(span);
    } else {
      // No text selected -> apply to whole contenteditable div
      this.editableContent.nativeElement.style.fontSize = `${this.fontSize}px`;
    }
  }

  searchContent() {
    const content = this.editableContent.nativeElement;
    const term = this.searchTerm.trim();

    if (!term) return;

    // Clear previous highlights
    this.clearHighlights();

    // Highlight all matches
    const regex = new RegExp('\\b(' + term + '\\b)', 'gi');
    content.innerHTML = content.innerHTML.replace(
      regex,

      (match) => `<span class="highlight" style="
    background-color: yellow; padding: 0 2px;
">${match}</span>`
    );

    // // Collect all matches
    // this.matches = Array.from(content.querySelectorAll('.highlight')) as HTMLElement[];

    // if (this.matches.length === 0) {
    //   this.currentIndex = 0;
    //   return;
    // }

    // // Move to next match
    // if (this.currentIndex >= this.matches.length) {
    //   this.currentIndex = 0; // loop back
    // }

    // const el = this.matches[this.currentIndex];
    // el.scrollIntoView({ behavior: 'smooth', block: 'center' });

    // // Add active highlight
    // this.matches.forEach((m) => m.classList.remove('active'));
    // el.classList.add('active');

    // this.currentIndex++;
  }

  private clearHighlights() {
    const content = this.editableContent.nativeElement;
    content.querySelectorAll('.highlight').forEach((el) => {
      el.replaceWith(document.createTextNode(el.textContent || ''));
    });
  }

  updateContent(event: Event) {
    const value = (event.target as HTMLElement).innerText;
    this.group.get('content')?.setValue(value);
  }
}
