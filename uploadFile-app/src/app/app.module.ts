import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { UploadComponent } from './components/upload/upload.component';
import { FileAdminComponent } from './components/file-admin/file-admin.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FileListComponent } from "./components/fileList/file-list.components";
import { FileSizePipe } from "./shared/fileSizePipe .pipe";
import { VirtualScrollerModule } from 'ngx-virtual-scroller';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    FileAdminComponent,
    UploadComponent,
    FileListComponent,
    FileSizePipe
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    VirtualScrollerModule,
    FormsModule,
    NgbModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
