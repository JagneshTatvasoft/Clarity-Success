import { Component, inject, Input, OnInit } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule, MatPseudoCheckbox } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { Clipboard } from '@angular/cdk/clipboard';
import { ControlContainer, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CustomerImageContainerComponent } from "../../customer-image-container/customer-image-container.component";

@Component({
  selector: 'app-customer-basic-info-form',
  imports: [
    MatFormFieldModule,
    MatSelectModule,
    MatOptionModule,
    MatInputModule,
    MatIconModule,
    ReactiveFormsModule,
    CustomerImageContainerComponent
],
  templateUrl: './customer-basic-info-form.component.html',
  styleUrl: './customer-basic-info-form.component.scss',
})
export class CustomerBasicInfoFormComponent implements OnInit {
  private cdkClipboard = inject(Clipboard);
  @Input() group!: FormGroup;

  // previewUrl: string | null = null;
  // selectedFile: File | null = null;

  // onFileSelected(event: Event): void {
  //   const input = event.target as HTMLInputElement;
  //   if (input.files && input.files[0]) {
  //     this.selectedFile = input.files[0];

  //     // show preview
  //     const reader = new FileReader();
  //     reader.onload = (e) => (this.previewUrl = reader.result as string);
  //     reader.readAsDataURL(this.selectedFile);
  //   }
  // }

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

  // Attempt to copy an image as an actual image into OS clipboard
  // async copyImageToClipboard() {
  //   debugger;
  //   window.focus();
  //   if (!this.previewUrls.length) return;
  //   const dataUrl = await fetch(this.previewUrls[this.currentIndex]);

  //   // Convert dataURL to Blob
  //   const blob = await dataUrl.blob();

  //   if (navigator.clipboard && (navigator.clipboard as any).write) {
  //     try {
  //       // Some TSs do not know ClipboardItem; use (window as any)
  //       const item = new ClipboardItem({'image/png': blob });
  //       await navigator.clipboard.write([item]);
  //       console.log('Image copied to clipboard (binary).');
  //       return;
  //     } catch (err) {
  //       console.warn('navigator.clipboard.write failed:', err);
  //     }
  //   }

  //   // Fallback: copy the dataURL text to clipboard (CDK copy)
  //   // this.cdkClipboard.copy(dataUrl);
  //   console.log('Copied data URL text to clipboard (fallback).');
  // }

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

  pasteImageFromClipboard() {
    debugger
    if (!navigator.clipboard || !navigator.clipboard.read) {
      console.warn('Clipboard read not supported.');
      return;
    }

    navigator.clipboard
      .read()
      .then((items) => {
        for (let i = 0; i < items.length; i++) {
          const item = items[i];
          const imageType = item.types.find((type) => type.startsWith('image/png'));
          if (imageType) {
            console.log(imageType + " - image type")
            return item.getType(imageType);
          }
        }
        throw new Error('No image found on clipboard.');
      })
      .then((blob) => {
        const reader = new FileReader();
        reader.onload = () => {
          debugger
          this.previewUrls.push(reader.result as string);
          this.currentIndex = this.previewUrls.length - 1;
        };
        reader.readAsDataURL(blob);
      })
      .catch((err) => {
        console.error('Paste failed', err);
      });
  }

  // async pasteImageFromClipboard() {
  //   debugger
  //   try {
  //     // request clipboard contents (requires https or localhost)
  //     const clipboardItems = await navigator.clipboard.read();

  //     for (const item of clipboardItems) {
  //       // find first image type (png, jpeg, etc.)
  //       const imageType = item.types.find((t) => t.startsWith('image/'));
  //       if (!imageType) continue;

  //       const blob = await item.getType(imageType);
  //       const reader = new FileReader();
  //       reader.onload = () => {
  //         this.previewUrls.push(reader.result as string);
  //         this.currentIndex = this.previewUrls.length - 1; // show newest
  //       };
  //       reader.readAsDataURL(blob);
  //       return; // stop after first image
  //     }

  //     console.warn('No image found on clipboard.');
  //   } catch (err) {
  //     console.error('Paste failed:', err);
  //   }
  // }

  // async pasteImage() {
  //   debugger
  //   try {
  //     const clipboardItems = await window.navigator.clipboard.read();
  //     for (const item of clipboardItems) {
  //       const type = item.types.find((t) => t.startsWith('image/'));
  //       if (type) {
  //         const blob = await item.getType(type);
  //         const url = URL.createObjectURL(blob);
  //         this.previewUrls.push(url);
  //         console.log('Image pasted from clipboard!');
  //         return;
  //       }
  //     }
  //     console.warn('No image found in clipboard.');
  //   } catch (err) {
  //     console.error('Paste failed', err);
  //   }
  // }

  // call this when you actually want to save to server
  // uploadImage() {
  //   if (!this.selectedFile) return;

  //   const formData = new FormData();
  //   formData.append('file', this.selectedFile);

  //   // example using Angular HttpClient
  //   // this.http.post('/api/upload', formData).subscribe(...)
  // }

  ngOnInit() {
    // this.group = this.controlContainer.control;
  }
}
