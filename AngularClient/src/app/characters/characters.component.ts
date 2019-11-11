import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth/auth.service';
import { DbndService } from '../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';

import { CharacterService } from "../_services/dataservice/character.service";

@Component({
  selector: 'app-characters',
  templateUrl: './characters.component.html',
  styleUrls: ['./characters.component.css']
})

export class CharactersComponent implements OnInit {

  constructor(public auth: AuthService, public dbnd: DbndService, private data: CharacterService) { }
  mode = 'characterSelection';
  form = 'new';
  dbndProfText = '';

  page = 1;
  pageSize = 4;
  collectionSize = 25; // Number of characters

  // get countries(): Country[] {
  //   return COUNTRIES
  //     .map((country, i) => ({id: i + 1, ...country}))
  //     .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
  // }

  async ngOnInit() {
    /*this.dbnd.getId$().subscribe((res: Response) => {
      this.dbnd.getUser$(res["id"]).subscribe( (res: Response) => {
        this.dbndProfText = JSON.stringify(res);
      })
    })*/
    this.data.currentMessage.subscribe( message => {
      this.mode = message;
    });

    this.data.currentForm.subscribe( form => {
      this.form = form;
    });

    this.dbnd.getUser$(await this.auth.getClientId()).subscribe( (res: Response) => {
      this.dbndProfText = JSON.stringify(res);
    });
  }

}


