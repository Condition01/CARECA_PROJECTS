import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Careca } from '../entities/Careca';

const AUTH_API = environment.apiUrl;

const httpOptionsSemAuth = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};

@Injectable({
  providedIn: 'root',
})
export class CarecaService {
  protected getUrl(): string {
    return AUTH_API + '/careca';
  }

  constructor(public http: HttpClient) {}

  public buscarCareca(): Observable<any> {
    return this.http
      .get(this.getUrl(), httpOptionsSemAuth)
      .pipe(catchError(this.handleError<Careca>(`buscarCareca=${1}`)));
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }
}
