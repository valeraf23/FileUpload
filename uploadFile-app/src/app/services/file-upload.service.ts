import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpProgressEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { FileModel } from "../models/file-model";

@Injectable({
  providedIn: 'root'
})
export class FileUploadService {

  constructor(private http: HttpClient) {}

  getFiles(): Observable<FileModel[]> {
    return this.http.get<FileModel[]>('api')
      .pipe(catchError(this.handleError));;
  }

  uploadFile(file: Blob): Observable<HttpEvent<HttpProgressEvent>> {
    const formData = new FormData();
    debugger;
    formData.append('file', file);
    return this.http.post<HttpProgressEvent>('api/upload',
      formData,
      {
        reportProgress: true,
        observe: 'events'
      }).pipe(catchError(this.handleError));
  }

  private handleError(err: HttpErrorResponse) {
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
