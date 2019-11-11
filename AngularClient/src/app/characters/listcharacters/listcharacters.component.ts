import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';

import { CharacterService } from "../../_services/dataservice/character.service";

@Component({
  selector: 'app-listcharacters',
  templateUrl: './listcharacters.component.html',
  styleUrls: ['./listcharacters.component.css']
})
export class ListcharactersComponent implements OnInit {
    dbndProfText = 'test';
    loadedInfo: Promise<string>;
    showSpinner = true;
    characters: any = [];
    mode = 'characterSelection';
    form = 'new'

  constructor(public auth: AuthService, public dbnd: DbndService, private data: CharacterService) { }

  onSubmit() {
    console.log( this.dbnd.getUserCharacters$(this.auth.clientId) );
  }

  async ngOnInit() {

    this.data.currentMessage.subscribe(message => this.mode = message);

    this.dbnd.getUser$(await this.auth.getClientId())
      .subscribe( (res: Response) => {this.dbndProfText = JSON.stringify(res);
                                      this.showSpinner = false;
                                      });

    this.dbnd.getUserCharacters$(this.auth.clientId)
      .subscribe( (data: {}) => {this.characters = data;
                                console.log(data);
                                this.showSpinner = false;
                                });
  }

  newMessage() {
    this.data.changeMessage("gameSelection")
  }

  changeTargetID(targetID: string) {
    this.data.changeTargetID(targetID)
  }

  changeForm(form: string) {
    this.data.changeForm(form)
  }

  onClickTableHandler(targetID: string){
    this.newMessage();
    this.changeTargetID(targetID);
  }

  onClickEditHandler(targetID: string, form: string){
    this.changeForm(form);
    this.changeTargetID(targetID);
  }

}
