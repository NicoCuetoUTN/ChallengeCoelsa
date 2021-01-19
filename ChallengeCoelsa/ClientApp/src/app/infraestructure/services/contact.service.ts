import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, finalize, map, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { BackEndResponse } from '../model/interfaces/backend-response.interface';
import { Contact } from '../model/interfaces/contact.interface';


@Injectable()
export class ContactService {
  private baseUrl: string = environment.api;
  private apiURL: string = "api/contact";

  constructor(private http: HttpClient) { }

  // get(): Observable<any> {
  //   // return this.http.get(this.baseUrl + "/GetAll").pipe(response => response.data)
  //   return this.http.get<BackEndResponse>(this.baseUrl + this.apiURL);
  // }

  get(): Observable<BackEndResponse> {
    return this.http.get<BackEndResponse>(this.baseUrl + this.apiURL).pipe(
     catchError((err) => this.handleError(err))
    );
 }

  // post(model: Contact): Observable<BackEndResponse> {
  //   return this.http.post<BackEndResponse>(this.baseUrl + this.apiURL, model);
  // }

  post(model: Contact): Observable<BackEndResponse> {
    const result = {
      params: new HttpParams(),
      headers: new HttpHeaders(),
   };
    return this.http.post<BackEndResponse>(this.baseUrl + this.apiURL, model, result).pipe(
      catchError((err)=> this.handleError(err))
    )
 }

  delete(modelId: string): Observable<BackEndResponse> {
    return this.http.delete<BackEndResponse>(this.baseUrl + this.apiURL + modelId)
    .pipe(map((response) => response));
    
 }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // Return an observable with a user-facing error message.
    return throwError(
      'Something bad happened; please try again later.');
  }

}
