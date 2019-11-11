import { Injectable } from '@angular/core';
import { DbndService } from '../dbnd/dbnd.service';
import { AuthService } from '../auth/auth.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { Game } from 'src/app/_models/game';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  constructor(private dbnd: DbndService, private auth: AuthService) {
    this.updateGames();
  }

  private _games: BehaviorSubject<Game[]> = new BehaviorSubject([]);
  public readonly games$: Observable<Game[]> = this._games.asObservable();

  public async updateGames() {
    this.dbnd.getUserGames$(await this.auth.getClientId()).subscribe( res => {
      this._games.next(res as Game[]);
    });
  }
}
