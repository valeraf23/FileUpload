import { Component, OnInit } from '@angular/core';
import { ProgressStatusEnum, ProgressStatus } from 'src/app/models/progress-status.model';
import { FileUploadService } from "../../services/file-upload.service";
import { FileModel } from "../../models/file-model";


@Component({
  selector: 'app-file-admin',
  templateUrl: './file-admin.component.html',
  styleUrls: ['./file-admin.component.css']
})
export class FileAdminComponent implements OnInit{

  ngOnInit(): void { this.getFiles(); }

  private files: FileModel[];
  public percentage: number;
  public showProgress: boolean;
  public showUploadError: boolean;
  public message: string;
  private _filter: string;
  public filteredFiles: FileModel[];

  public get filter(): string {
    return this._filter;
  }

  public set filter(value: string) {
    this._filter = value;
    this.filteredFiles = this.filter ? this.performFilter(this.filter) : this.files;
  }

  constructor(private fileUploadService: FileUploadService) {}

  private performFilter(filterBy: string): FileModel[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.files.filter((g: FileModel) => g.name.toLocaleLowerCase().indexOf(filterBy) !== -1);
  }

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
        this.filteredFiles = data;
      }
    );
  }
}
