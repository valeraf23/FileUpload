import { Component } from '@angular/core';
import { ProgressStatusEnum, ProgressStatus } from 'src/app/models/progress-status.model';
import { FileGetService } from "../../services/file-get.service";


@Component({
  selector: 'app-filemanager',
  templateUrl: './file-manager.component.html',
  styles: [
    `
.upload{
    font-weight:bold;
    color:#28a745;
    margin-left: 15px;
    line-height: 36px;
}
`
  ]
})
export class FileManagerComponent {

  public files: string[];
  public fileInDownload: string;
  public percentage: number;
  public showProgress: boolean;
  public showDownloadError: boolean;
  public showUploadError: boolean;
  public message: string;

  constructor(private service: FileGetService) {}

  public uploadStatus(event: ProgressStatus) {
    switch (event.status) {
    case ProgressStatusEnum.START:
      this.showUploadError = false;
      break;
    case ProgressStatusEnum.IN_PROGRESS:
      this.showProgress = true;
      this.percentage = event.percentage;
      break;
    case ProgressStatusEnum.COMPLETE:
      this.showProgress = false;
      this.message = 'Upload success.';
        this.service.getFiles();
      break;
    case ProgressStatusEnum.ERROR:
      this.showProgress = false;
      this.showUploadError = true;
      this.message = 'Occurred error during upload.';
      break;
    }
  }
}
