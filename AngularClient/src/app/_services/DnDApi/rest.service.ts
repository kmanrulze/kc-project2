import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';

const endpoint = 'http://www.dnd5eapi.co/api/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

@Injectable({
  providedIn: 'root'

})
export class RestService {

  constructor(private http: HttpClient) { }
  private extractData(res: Response) {
    const body = res;
    return body || { };
  }
  getMonsters(): Observable<any> {
    return this.http.get(endpoint + 'monsters/').pipe(
      map(this.extractData));
  }
  getMonster(id): Observable<any> {
    return this.http.get(endpoint + 'monsters/' + id).pipe(
      map(this.extractData));
  }
}
