import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { DbndService } from '../dbnd/dbnd.service';
import { AuthService } from '../auth/auth.service';
import { Character } from '../../_models/character';

@Injectable({
  providedIn: 'root'
})
export class CharacterService {

  /* private messageSource = new BehaviorSubject('characterSelection');
  currentMessage = this.messageSource.asObservable();

  private targetIDSource = new BehaviorSubject('null');
  currentTargetID = this.targetIDSource.asObservable();

  private formSource = new BehaviorSubject('new');
  currentForm = this.formSource.asObservable();

  constructor() { }

  changeMessage(message: string) {
    this.messageSource.next(message)
  }

  changeTargetID(targetID: string) {
    this.targetIDSource.next(targetID)
  }

  changeForm(form: string) {
    this.formSource.next(form)
  } */

  constructor(private dbnd: DbndService, private auth: AuthService) {
    this.updateCharacters();
  }

  private _characters: BehaviorSubject<Character[]> = new BehaviorSubject([]);
  public readonly characters$: Observable<Character[]> = this._characters.asObservable();

  public async updateCharacters() {
    this.dbnd.getUserCharacters$(await this.auth.getClientId()).subscribe( res => {
      this._characters.next(res as Character[]);
    });
  }
}
