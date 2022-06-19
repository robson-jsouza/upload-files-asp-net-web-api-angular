import { Component, ElementRef, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'upload-files';
  body: string = '';
  physicalFiles: any[] = [];
  message: string = '';
  files: any[] = [];

  @ViewChild('fileInput')
  fileInput!: ElementRef;

  @ViewChild('fileInput2')
  fileInput2!: ElementRef;

  onFileSelected(event: any) {
    if (event.target.files.length > 0) {
      this.physicalFiles.push(event.target.files[0]);
    }
  }

  onAdd(): void {
    this.files.push({ body: this.body, files: this.physicalFiles, message: this.message });
    this.body = '';
    this.physicalFiles = [];
    this.message = '';
    this.fileInput.nativeElement.value = "";
    this.fileInput2.nativeElement.value = "";
  }

  onPost(): void {
    let formData = new FormData();
    for (var index = 0; index < this.files.length; index++) {
      this.createsFormData(index, formData, this.files[index]);
    }
    this.files = [];

    this.http.post<any>('http://localhost:62966/File', formData).subscribe(data => {
    });
  }

  createsFormData(index: number, formData: FormData, object: any, arrayName: string = ''): FormData {
    for (const [key, value] of Object.entries(object)) {
      if (Array.isArray(value)) {
        this.createsFormData(index, formData, value, key);
      } else {
        const propertyValue: any = value;
        let formDataIndex = `files[${index}]`;
        if (arrayName)
          formDataIndex += `.${arrayName}`;
        else
          formDataIndex += `.${key}`;
        formData.append(formDataIndex, propertyValue);
      }
    }

    return formData;
  }

  constructor(private http: HttpClient) { }
}
