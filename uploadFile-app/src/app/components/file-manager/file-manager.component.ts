import { Component, OnInit } from '@angular/core';
import { ProgressStatusEnum, ProgressStatus } from 'src/app/models/progress-status.model';
import { FileUploadService } from "../../services/file-upload.service";
import { FileModel } from "../../models/file-model";


@Component({
  selector: 'app-filemanager',
  templateUrl: './file-manager.component.html',
  styleUrls: ['./file-manager.component.css']
})
export class FileManagerComponent implements OnInit{

  ngOnInit(): void { this.getFiles(); }

  public files: FileModel[];
  public percentage: number;
  public showProgress: boolean;
  public showUploadError: boolean;
  public message: string;

  constructor(private fileUploadService: FileUploadService) {}

  public uploadStatus(event: ProgressStatus):void {
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
      this.getFiles();
      break;
    case ProgressStatusEnum.ERROR:
      this.showProgress = false;
      this.showUploadError = true;
      this.message = 'Occurred error during upload.';
      break;
    }
  }

  public getFiles(): void {
    this.fileUploadService.getFiles().subscribe(
      data => {
        this.files = data;
      }
    );
  }
}
