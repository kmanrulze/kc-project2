import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DbndService {

  constructor(private http: HttpClient) { }

  // Example GET request to local endpoint
  ping$(): Observable<any> {
    return this.http.get('/api/external');
  }

}