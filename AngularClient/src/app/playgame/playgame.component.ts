// import { Component, OnInit, Input } from '@angular/core';
// import { AuthService } from '../_services/auth/auth.service';
// import { DbndService } from '../_services/dbnd/dbnd.service';
// import { Observable } from 'rxjs';

// import { ActivatedRoute } from '@angular/router';
// import { switchMap } from 'rxjs/operators';

// @Component({
//   selector: 'app-playgame',
//   templateUrl: './playgame.component.html',
//   styleUrls: ['./playgame.component.css']
// })
// export class PlaygameComponent implements OnInit {
//   dbndProfText = '';
//   showSpinner = true;
//   mode = 'description';
//   currentGameID = '';
//   currentClientID = '';
//   currentGameInfo: any = [];
//   targetCharacterID = '';

//   constructor(public auth: AuthService, public dbnd: DbndService, private route: ActivatedRoute) { }

//   async ngOnInit() {

//     this.currentGameID = this.route.snapshot.paramMap.get("gameID");
//     this.currentClientID = this.route.snapshot.paramMap.get("clientID");

//     console.log("GameID - " + this.currentGameID);
//     console.log("ClientID - " + this.currentClientID);

//     this.dbnd.getGame$(this.currentClientID, this.currentGameID)
//                             .subscribe( res  => {
//                               this.currentGameInfo = res;
//                               console.log(this.currentGameInfo)
//                             });

//     console.log(this.currentGameInfo)
//   }
// }
