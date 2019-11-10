import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';

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

  constructor(public auth: AuthService, public dbnd: DbndService) { }

  onSubmit() {
    console.log( this.dbnd.getUserCharacters$(this.auth.clientId) );
  }

  async ngOnInit() {

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

}
