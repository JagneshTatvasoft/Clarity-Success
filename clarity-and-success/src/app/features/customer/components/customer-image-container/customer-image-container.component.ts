import { Component, inject } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { Clipboard } from '@angular/cdk/clipboard';

@Component({
  selector: 'app-customer-image-container',
  imports: [
    MatFormFieldModule,
    MatSelectModule,
    MatOptionModule,
    MatInputModule,
    MatIconModule,
    ReactiveFormsModule,
  ],
  templateUrl: './customer-image-container.component.html',
  styleUrl: './customer-image-container.component.scss',
})
export class CustomerImageContainerComponent {
  private cdkClipboard = inject(Clipboard);

  previewUrls: string[] = []; // all uploaded image previews
  currentIndex = 0; // which image is showing now

  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files[0]) {
      const file = input.files[0];

      const reader = new FileReader();
      reader.onload = () => {
        this.previewUrls.push(reader.result as string);
        this.currentIndex = this.previewUrls.length - 1; // show the latest upload
      };
      reader.readAsDataURL(file);
    }
  }

  /** Simple next/prev – stops at ends */
  showPrevious(): void {
    if (this.currentIndex > 0) {
      this.currentIndex--;
    }
  }

  showNext(): void {
    if (this.currentIndex < this.previewUrls.length - 1) {
      this.currentIndex++;
    }
  }

  /** Remove current image */
  removeCurrent(): void {
    if (!this.previewUrls.length) return;
    this.previewUrls.splice(this.currentIndex, 1);
    if (this.currentIndex >= this.previewUrls.length) {
      this.currentIndex = Math.max(0, this.previewUrls.length - 1);
    }
  }

  copyImageToClipboard() {
    debugger;
    if (this.previewUrls.length) {
      fetch(this.previewUrls[this.currentIndex])
        .then((res) => res.blob())
        // .then(async (blob) => {
        //   // Force convert to PNG, since Chrome only allows PNG on clipboard.write
        //   const bitmap = await createImageBitmap(blob);
        //   const canvas = document.createElement('canvas');
        //   canvas.width = bitmap.width;
        //   canvas.height = bitmap.height;

        //   const ctx = canvas.getContext('2d');
        //   ctx?.drawImage(bitmap, 0, 0);

        //   return new Promise<Blob | null>((resolve) => {
        //     canvas.toBlob(resolve, 'image/png');
        //   });
        // })
        .then((pngBlob) => {
          if (pngBlob) {
            const item = new ClipboardItem({ 'image/png': pngBlob });
            return navigator.clipboard.write([item]);
          } else {
            throw new Error('PNG conversion failed');
          }
        })
        .then(() => {
          console.log('Image copied as PNG!');
        })
        .catch((err) => {
          console.error('Copy failed', err);
        });
    }
  }

  async pasteImage() {
    debugger;
    try {
      const clipboardItems = await window.navigator.clipboard.read();
      for (const item of clipboardItems) {
        const type = item.types.find((t) => t.startsWith('image/'));
        if (type) {
          const blob = await item.getType(type);
          const url = URL.createObjectURL(blob);
          this.previewUrls.push(url);
          console.log('Image pasted from clipboard!');
          return;
        }
      }
      console.warn('No image found in clipboard.');
    } catch (err) {
      console.error('Paste failed', err);
    }
  }
}
