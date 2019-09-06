import { Component, Input } from '@angular/core';
import { FileModel } from "../../models/file-model";

@Component({
  selector: 'file-list',
  templateUrl: './file-list.component.html'
})
export class FileListComponent{

  @Input() public fileModels: FileModel[];

}
