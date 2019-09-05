import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { FileModel } from "../models/file-model";

@Injectable({
  providedIn: 'root'
})
export class FileGetService {

  private searchQuerySource = new Subject<FileModel[]>();

  getFiles$ = this.searchQuerySource.asObservable();

  getFiles(): void {
    this.searchQuerySource.next();
  }

}
