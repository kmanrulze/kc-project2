import { Injectable } from '@angular/core';
import { DbndService } from '../dbnd/dbnd.service';
import { AuthService } from '../auth/auth.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { Game } from 'src/app/_models/game';

@Injectable({
  providedIn: 'root'
})
export class OverviewService {

  constructor(private dbnd: DbndService, private auth: AuthService) {
    this.updateOverviews();
  }

  private _overviews: BehaviorSubject<Game[]> = new BehaviorSubject([]);
  public readonly overviews$: Observable<Game[]> = this._overviews.asObservable();

  public async updateOverviews() {
    this.dbnd.getGameOverviews$(await this.auth.getClientId(), 'gameId')
    .subscribe( res => {this._overviews.next(res as Overview[])});
  }

}
