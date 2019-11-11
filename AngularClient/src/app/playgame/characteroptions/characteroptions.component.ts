import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';

import { PlaygameComponent } from '../playgame.component';

@Component({
  selector: 'app-characteroptions',
  templateUrl: './characteroptions.component.html',
  styleUrls: ['./characteroptions.component.css']
})
export class CharacteroptionsComponent implements OnInit {
  dbndProfText = '';
  showSpinner = true;
  characterSelected = false;
  @Input() currentGameID: any;
  @Input() currentGameInfo: any;
  @Input() currentClientID: string;
  
  constructor(public auth: AuthService, public dbnd: DbndService) { }

  async ngOnInit() {

    console.log(this.currentGameInfo)
    this.dbnd.getUser$(await this.auth.getClientId())
      .subscribe( (res: Response) => {this.dbndProfText = JSON.stringify(res);
                                      this.showSpinner = false;
      });
    }

}
