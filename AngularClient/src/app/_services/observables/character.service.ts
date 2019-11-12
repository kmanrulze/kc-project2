import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { DbndService } from '../dbnd/dbnd.service';
import { AuthService } from '../auth/auth.service';
import { Character } from '../../_models/character';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class CharacterService {

  constructor(private dbnd: DbndService, private user: UserService) {
    this.updateCharacters().then();
  }

  private _characters: BehaviorSubject<Character[]> = new BehaviorSubject([]);
  public readonly characters$: Observable<Character[]> = this._characters.asObservable();

  public async updateCharacters() {
    this.user.userId$.subscribe( id => {
      this.dbnd.getUserCharacters$(id).subscribe( res => {
        console.log(res);
        this._characters.next(res);
      });
    });
  }
}
