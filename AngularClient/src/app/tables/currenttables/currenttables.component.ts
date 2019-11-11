import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';
import { GameService } from 'src/app/_services/observables/game.service';
import { UserService } from 'src/app/_services/observables/user.service';

@Component({
  selector: 'app-currenttables',
  templateUrl: './currenttables.component.html',
  styleUrls: ['./currenttables.component.css']
})
export class CurrenttablesComponent implements OnInit {
  dbndProfText = '';
  showSpinner = true;
  currentId: string;
  constructor( public gameService: GameService, public user: UserService ) { }

  async ngOnInit() {
    
    this.user.userId$.subscribe( res => this.currentId = res);

    this.gameService.games$.subscribe( async res => {
      this.showSpinner = false;
    });
  }
}
