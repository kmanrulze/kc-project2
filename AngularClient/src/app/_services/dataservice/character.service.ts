import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CharacterService {

  private messageSource = new BehaviorSubject('characterSelection');
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
  }

}
