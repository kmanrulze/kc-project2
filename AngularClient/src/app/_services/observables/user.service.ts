import { Injectable } from '@angular/core';
import { DbndService } from '../dbnd/dbnd.service';
import { AuthService } from '../auth/auth.service';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private dbnd: DbndService) {
    this.updateId().then();
  }

  private _userId: BehaviorSubject<string> = new BehaviorSubject('');
  public readonly userId$: Observable<string> = this._userId.asObservable();

  public async updateId() {
    this.dbnd.getId$().subscribe( res => {
      this._userId.next(res.id);
    });
  }
}
