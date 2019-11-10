import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth/auth.service';
import { DbndService } from '../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-playgame',
  templateUrl: './playgame.component.html',
  styleUrls: ['./playgame.component.css']
})
export class PlaygameComponent implements OnInit {
  dbndProfText = '';
  showSpinner = true;
  mode = 'description';
  constructor(public auth: AuthService, public dbnd: DbndService) { }

  async ngOnInit() {

    this.dbnd.getUser$(await this.auth.getClientId())
      .subscribe( (res: Response) => {this.dbndProfText = JSON.stringify(res);
                                      this.showSpinner = false;
      });
    }

}
