import { Component, Output, EventEmitter, Input, ViewChild, ElementRef } from '@angular/core';
import { HttpEventType } from '@angular/common/http';
import { ProgressStatus, ProgressStatusEnum } from 'src/app/models/progress-status.model';
import { FileUploadService } from 'src/app/services/file-upload.service';


@Component({
  selector: 'app-upload',
  templateUrl: 'upload.component.html',
  styles: [`button {margin:1%}`]
})

export class UploadComponent {
  @Input() public disabled: boolean;
  @Output() public uploadStatus: EventEmitter<ProgressStatus> = new EventEmitter<ProgressStatus>();
  @ViewChild('inputFile', { static: false }) private inputFile: ElementRef;

  constructor(private fileUploadService: FileUploadService) {
  }

  public upload(event) {
    if (event.target.files && event.target.files.length > 0) {
      const file = event.target.files[0];
      this.uploadStatus.emit({ status: ProgressStatusEnum.START });
      this.fileUploadService.uploadFile(file).subscribe(
        data => {
          if (data) {
            debugger;
            switch (data.type) {
              case HttpEventType.UploadProgress:
                this.uploadStatus.emit( {status: ProgressStatusEnum.IN_PROGRESS, percentage: Math.round((data.loaded / data.total) * 100)});
                break;
              case HttpEventType.Response:
                this.inputFile.nativeElement.value = '';
                this.uploadStatus.emit( {status: ProgressStatusEnum.COMPLETE});
                break;
            }
          }
        },
        error => {
          this.inputFile.nativeElement.value = '';
          this.uploadStatus.emit( {status: ProgressStatusEnum.ERROR});
        }
      );
    }
  }
}
