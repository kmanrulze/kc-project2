import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';
import { Character } from '../../_models/character';
import { NgForm } from '@angular/forms';
import { HttpResponse } from '@angular/common/http';
import { CharacterService } from 'src/app/_services/observables/character.service';


@Component({
  selector: 'app-newform',
  templateUrl: './newform.component.html',
  styleUrls: ['../characters.component.css']
})
export class NewFormComponent implements OnInit {
  constructor(public auth: AuthService, public dbnd: DbndService, public characterService: CharacterService) { }

  dbndProfText = '';

  async ngOnInit() {
    /* this.dbnd.getUser$(await this.auth.getClientId()).subscribe( (res: Response) => {
      this.dbndProfText = JSON.stringify(res);
    }); */
  }

  async onSubmit(CharacterForm: NgForm) {
    console.log(CharacterForm.value);

    const character: Character = new Character(CharacterForm.value.FirstName, CharacterForm.value.LastName);
    console.log(character);

    this.dbnd.createCharacter$(await this.auth.getClientId(), character).subscribe(createRes => {
      console.log(createRes);
      // Handle response here: success, failure. Suggest creating alert or third message text idk
      CharacterForm.resetForm();
      this.characterService.updateCharacters();
    });
  }
}
