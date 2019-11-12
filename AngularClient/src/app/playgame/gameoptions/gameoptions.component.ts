import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';
import { UserService } from 'src/app/_services/observables/user.service';

import { NgForm } from '@angular/forms';
import { HttpResponse } from '@angular/common/http';
import { Router } from '@angular/router';


import { Game } from '../../_models/game';

import { PlaygameComponent } from '../playgame.component';

@Component({
  selector: 'app-gameoptions',
  templateUrl: './gameoptions.component.html',
  styleUrls: ['./gameoptions.component.css']
})
export class GameoptionsComponent implements OnInit {
  dbndProfText = '';
  showSpinner = true;
  @Input() currentGameInfo: any;
  @Input() currentClientID: string;
  @Input() currentGameID: string;
  @Input() targetCharacterID: string;

  constructor(public auth: AuthService, public dbnd: DbndService, public router: Router, public userService: UserService) { }

  async ngOnInit() {
    console.log("currentgameid " + this.currentGameID);
    }

    async onAddCharacterSubmit(AddCharacterForm: NgForm) {
      console.log(AddCharacterForm.value);

      this.dbnd.addCharacterToGame$(this.currentClientID, this.currentGameID, AddCharacterForm.value.CharacterID)
        .subscribe(createRes => {
        console.log(createRes);
        // Handle response here: success, failure. Suggest creating alert or third message text idk
        AddCharacterForm.resetForm();
        //this.characterService.updateCharacters();
      });
    }

    async onDeleteTableSubmit(DeleteTableForm: NgForm) {
      console.log(DeleteTableForm.value);

      this.dbnd.deleteGame$(this.currentClientID, this.currentGameID).subscribe(createRes => {
        console.log(createRes);
        // Handle response here: success, failure. Suggest creating alert or third message text idk
        DeleteTableForm.resetForm();
        this.router.navigate(['profile'])
        //this.characterService.updateCharacters();
      });
      }

    async onChangeTableSubmit(ChangeTableForm: NgForm) {

      let game: Game = new Game(ChangeTableForm.value.TableName, this.currentClientID);
      console.log(game);

      this.dbnd.updateGame$(this.currentClientID, this.currentGameID, game)
        .subscribe(createRes => {
              console.log(createRes);
        // Handle response here: success, failure. Suggest creating alert or third message text idk
        ChangeTableForm.resetForm();
        //this.characterService.updateCharacters();
      });
    }
}
