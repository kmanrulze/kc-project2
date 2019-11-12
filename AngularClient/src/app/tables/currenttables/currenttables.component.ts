import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';
import { GameService } from 'src/app/_services/observables/game.service';
import { UserService } from 'src/app/_services/observables/user.service';

import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';

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
  constructor( public gameService: GameService, public auth: AuthService, private router: Router, public userService: UserService ) { }

  async ngOnInit() {
    this.userService.userId$.subscribe( async res => { this.currentId = res; });

  }
  getGames() {
    this.gameService.games$.subscribe( async res => {
      console.log(res);
      this.showSpinner = false;
      this.games = res;
    });
  }

  onClickPlayGameHandler(gameId: string, clientId: string){
    console.log(gameId, clientId)
    this.router.navigate(['playgame', {gameID: gameId, clientID: clientId}]);
  }

}
