import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';
import { GameService } from 'src/app/_services/observables/game.service';

@Component({
  selector: 'app-currenttables',
  templateUrl: './currenttables.component.html',
  styleUrls: ['./currenttables.component.css']
})
export class CurrenttablesComponent implements OnInit {
  dbndProfText = '';
  showSpinner = true;
  currentId: string;
  games: any = [];
  constructor( public gameService: GameService, public auth: AuthService ) { }

  async ngOnInit() {

    await this.auth.getClientId().then( res => this.currentId = res);
    this.getGames();

  }
  getGames() {
    this.gameService.games$.subscribe( async res => {
      this.showSpinner = false;
      this.games = res;
    });
  }
}
