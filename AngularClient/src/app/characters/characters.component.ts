import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth/auth.service';
import { DbndService } from '../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';

import { CharacterService } from '../_services/observables/character.service';
import { ListcharactersComponent } from './listcharacters/listcharacters.component';
import { Character } from '../_models/character';

@Component({
  selector: 'app-characters',
  templateUrl: './characters.component.html',
  styleUrls: ['./characters.component.css']
})

export class CharactersComponent implements OnInit {

  constructor(public auth: AuthService, public dbnd: DbndService, private characterService: CharacterService) { }

  // Options: characterSelection, gameSelection
  mode = 'characterSelection';
  editingCharacter: Character;
  editingCharacterId: string;
  // Options: new, edit
  form = 'new';

  page = 1;
  pageSize = 4;
  collectionSize = 25;

  async ngOnInit() {
    this.auth.getClientId().then( async res => {
      await this.characterService.updateCharacters();
    });
  }

  async switchMode(emission: any) {
    await this.auth.getClientId().then( async res => {
      this.dbnd.getCharacter$( res, emission.characterId).subscribe (res => {
        this.editingCharacter = res;
        this.editingCharacterId = emission.characterId;
        this.form = emission.newFormMode;
      });
    });
  }

  async submitEditAndReset(characterId: string) {
    this.form = 'new';
    await this.characterService.updateCharacters();
  }

  async clickJoinTable(characterId: string) {
    this.mode = 'gameSelection';
  }

  async submitDelete(emission: any) {
    this.form = emission;
    await this.characterService.updateCharacters();
  }
}


