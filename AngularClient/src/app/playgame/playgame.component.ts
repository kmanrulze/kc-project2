import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../_services/auth/auth.service';
import { DbndService } from '../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';

import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs/operators';

import { UserService } from '../_services/observables/user.service';

@Component({
  selector: 'app-playgame',
  templateUrl: './playgame.component.html',
  styleUrls: ['./playgame.component.css']
})
export class PlaygameComponent implements OnInit {
  dbndProfText = '';
  showSpinner = true;
  mode = 'description';
  currentGameID = '';
  currentClientID = '';
  currentGameInfo: any = {};
  targetCharacterID = '';

  constructor(public auth: AuthService, public dbnd: DbndService, private route: ActivatedRoute, public userService: UserService) { }

  async ngOnInit() {

    this.currentGameID = this.route.snapshot.paramMap.get("gameID");

    this.userService.userId$.subscribe( res => this.currentClientID = res );

    this.dbnd.getGame$(this.currentClientID, this.currentGameID)
                            .subscribe( ( res )  => {
                              this.currentGameInfo = JSON.parse( JSON.stringify(res) ); //I'm sorry
                            });
}
}
