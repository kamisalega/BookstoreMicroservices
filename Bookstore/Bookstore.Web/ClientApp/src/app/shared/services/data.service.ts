import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {catchError, tap} from "rxjs/operators";
import {Observable, throwError} from "rxjs";
import {SecurityService} from "./security.service";
import {Guid} from "../../../../guid";

@Injectable()
export class DataService {

  constructor(private http: HttpClient,
              private securityService: SecurityService) {
  }

  get(url: string, params?: any): Observable<Response> {
    let options = {};
    this.setHeaders(options);

    return this.http.get(url, options)
      .pipe(
        // retry(3), // retry a failed request up to 3 times
        tap((res: Response) => {
          return res;
        }),
        catchError(this.handleError)
      );
  }

  private handleError(error: any) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('Client side network error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error('Backend - ' +
        `status: ${error.status}, ` +
        `statusText: ${error.statusText}, ` +
        `message: ${error.error.message}`);
    }

    // return an observable with a user-facing error message
    return throwError(error || 'server error');
  }

  private setHeaders(options: any, needId?: boolean) {
    if (needId && this.securityService) {
      options["headers"] = new HttpHeaders()
        .append('authorization', 'Bearer ' + this.securityService.getToken())
        .append('x-requestid', Guid.newGuid())
    } else if (this.securityService) {
      options["headers"] = new HttpHeaders()
        .append('authorization', 'Bearer ' + this.securityService.getToken());
    }
  }

  post(url: string, data: any, params?: any): Observable<Response> {
    return this.doPost(url, data, false, params)
  }

  put(url: string, data: any, params?: any): Observable<Response> {
    return this.doPut(url, data, false, params);
  }

  delete(url: string, params?: any): Observable<Response> {
    return this.doDelete(url, false, params);
  }

  private doPost(url: string, data: any, needId: boolean, params?: any): Observable<Response> {
    let options = {};

    this.setHeaders(options, needId);

    return this.http.post(url, data, options)
      .pipe(
        tap((res: Response) => {
          return res;
        }),
        catchError(this.handleError)
      );
  }

  private doPut(url: string, data: any, needId: boolean, params: any): Observable<Response> {
    let options = {};

    this.setHeaders(options, needId);

    return this.http.put(url, data, options)
      .pipe(
        tap((res: Response) => {
          return res;
        }),
        catchError(this.handleError)
      );
  }

  private doDelete(url: string, needId: boolean, params: any) {
    let options = {};

    this.setHeaders(options, needId);

    return this.http.delete(url, options)
      .pipe(
        tap((res: Response) => {
          return res;
        }),
        catchError(this.handleError)
      );
  }
}
