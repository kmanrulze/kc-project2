import { Injectable } from '@angular/core';
import { DbndService } from '../dbnd/dbnd.service';
import { AuthService } from '../auth/auth.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { Game } from 'src/app/_models/game';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  userId: string;

  constructor (private dbnd: DbndService, private user: UserService) {
    user.userId$.subscribe( id => {
      this.userId = id;
      this.updateGames();
    });
  }

  private _games: BehaviorSubject<Game[]> = new BehaviorSubject([]);
  public readonly games$: Observable<Game[]> = this._games.asObservable();

  public async updateGames() {
    this.dbnd.getUserGames$(this.userId).subscribe( res => {
      this._games.next(res as Game[]);
    });
  }
}
