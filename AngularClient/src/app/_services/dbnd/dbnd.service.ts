import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DbndService {

  constructor(private http: HttpClient) { }

  getId$(): Observable<any> {
    return this.http.get('https://dbndapi.azurewebsites.net/api/client/');
  }

  getUser$(id: string): Observable<any> {
    return this.http.get(`https://dbndapi.azurewebsites.net/api/client/${id}/`);
  }

  getUserCharacters$(id: string): Observable<any> {
    return this.http.get(`https://dbndapi.azurewebsites.net/api/client/${id}/characters/`)
  }

}
