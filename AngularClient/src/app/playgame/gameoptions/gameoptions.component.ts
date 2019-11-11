import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';

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

  constructor(public auth: AuthService, public dbnd: DbndService, public router: Router) { }

  async ngOnInit() {

    this.dbnd.getUser$(await this.auth.getClientId())
      .subscribe( (res: Response) => {this.dbndProfText = JSON.stringify(res);
                                      this.showSpinner = false;
      });
    }

    async onAddCharacterSubmit(AddCharacterForm: NgForm) {
      console.log(AddCharacterForm.value);
  
      this.dbnd.addCharacterToGame$(await this.auth.getClientId(), this.currentGameInfo.gameId, AddCharacterForm.value.CharacterID).subscribe(createRes => {
        console.log(createRes);
        // Handle response here: success, failure. Suggest creating alert or third message text idk
        AddCharacterForm.resetForm();
        //this.characterService.updateCharacters();
      });
    } 

    async onDeleteTableSubmit(DeleteTableForm: NgForm) {
      console.log(DeleteTableForm.value);

      this.dbnd.deleteGame$(await this.auth.getClientId(), this.currentGameInfo.gameId).subscribe(createRes => {
        console.log(createRes);
        // Handle response here: success, failure. Suggest creating alert or third message text idk
        DeleteTableForm.resetForm();
        this.router.navigate(['profile'])
        //this.characterService.updateCharacters();
      });
      } 


    // deleteGame$(clientId: string, gameId: string): Observable<any> {
    //   return this.http.delete(`${this.baseUrl}/${clientId}/games/${gameId}/delete`);
    // }

    async onChangeTableSubmit(ChangeTableForm: NgForm) {
      console.log(ChangeTableForm.value);

      let game: Game = new Game(ChangeTableForm.value.TableName, this.currentClientID);
      console.log(game);

      this.dbnd.updateGame$(await this.auth.getClientId(), this.currentGameInfo.gameId, game).subscribe(createRes => {
        console.log(createRes);
        // Handle response here: success, failure. Suggest creating alert or third message text idk
        ChangeTableForm.resetForm();
        //this.characterService.updateCharacters();
      });
    } 

    // updateGame$(clientId: string, gameId: string, game: Game) {
    //   return this.http.put(`${this.baseUrl}/${clientId}/games/${gameId}/update`, game);
    // }

}
