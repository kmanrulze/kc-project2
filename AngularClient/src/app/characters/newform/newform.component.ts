import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';
import { Character } from '../../_models/character';
import { NgForm } from '@angular/forms';
import { HttpResponse } from '@angular/common/http';
import { CharacterService } from 'src/app/_services/observables/character.service';
import { UserService } from 'src/app/_services/observables/user.service';


@Component({
  selector: 'app-newform',
  templateUrl: './newform.component.html',
  styleUrls: ['../characters.component.css']
})
export class NewFormComponent implements OnInit {

  constructor(public dbnd: DbndService, private user: UserService, public characterService: CharacterService) { }

  userId: string;

  ngOnInit() {
    this.user.userId$.subscribe( id => this.userId = id);
  }

  async onSubmit(CharacterForm: NgForm) {
    console.log(CharacterForm.value);

    const character: Character = new Character();
    character.ClientID = this.userId;
    character.FirstName = CharacterForm.value.FirstName;
    character.LastName = CharacterForm.value.LastName;
    console.log(character);

    this.dbnd.createCharacter$( this.userId, character).subscribe(async createRes => {
      console.log(createRes);
      // Handle response here: success, failure. Suggest creating alert or third message text idk
      CharacterForm.resetForm();
    });
  }
}
