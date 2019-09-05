import { Component, OnInit } from '@angular/core';
import { FileUploadService } from "../../services/file-upload.service";
import { FileModel } from "../../models/file-model";
import { FileGetService } from "../../services/file-get.service";


@Component({
  selector:'file-list',
  templateUrl: './file-list.component.html'
})

export class FileListComponent implements OnInit{
  public files: FileModel[];

  constructor(private service: FileUploadService, private fileGetService: FileGetService) { }

  ngOnInit() {
    this.fileGetService.getFiles$.subscribe(() => {
        this.getFiles();
      }
    );
    this.getFiles();
  }

  public getFiles() {
    this.service.getFiles().subscribe(
      data => {
        this.files = data;
      }
    );
  }
}
