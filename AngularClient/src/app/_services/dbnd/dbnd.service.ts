import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DbndService {

  constructor(private http: HttpClient) { }

  domain: string = "dbnd.auth0.com";
  client_id: string = "7cgrbDfEj2bunK7qBIVtKotF89U0g5eh";
  audience: string = "/dbnd";

  getId$(): Observable<any> {
    return this.http.get(`${this.domain}/api/user/profile`);
  }

}