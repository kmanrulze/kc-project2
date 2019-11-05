import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { AuthService } from '../auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class DbndService {

  constructor(private http: HttpClient, private auth: AuthService) { }

  getId$(): Observable<any> {
    return this.http.get("/api/client");
  }

}