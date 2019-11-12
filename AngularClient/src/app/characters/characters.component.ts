import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth/auth.service';
import { DbndService } from '../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';

import { CharacterService } from "../_services/observables/character.service";
import { ListcharactersComponent } from './listcharacters/listcharacters.component';
import { Character } from '../_models/character';
import { UserService } from '../_services/observables/user.service';

@Component({
  selector: 'app-characters',
  templateUrl: './characters.component.html',
  styleUrls: ['./characters.component.css']
})

export class CharactersComponent implements OnInit {

  userId: string;
  // Options: characterSelection, gameSelection
  mode = 'characterSelection';
  editingCharacter: Character;
  editingCharacterId: string;
  // Options: new, edit, delete
  form = 'new';

  page = 1;
  pageSize = 4;
  collectionSize = 25;

  constructor(public dbnd: DbndService, public user: UserService, private characterService: CharacterService) {
    this.user.userId$.subscribe( id => this.userId = id );
  }

  ngOnInit() { 
    
  }

  async switchMode(emission: any) {
    this.dbnd.getCharacter$( this.userId, emission.characterId ).subscribe (res => {
      this.editingCharacter = res;
      console.log(`Editing:`);
      console.log(res);
      this.editingCharacterId = emission.characterId;
      this.form = emission.newFormMode;
    });
  }

  async submitEditAndReset(characterId: string) {
    this.characterService.updateCharacters().then( res => {
      this.form = 'new';
    });
  }

  async clickJoinTable(characterId: string) {
    this.mode = 'gameSelection';
  }

  async submitDelete(emission: any) {
    this.characterService.updateCharacters().then( res => {
      this.form = emission;
    });
  }
}


