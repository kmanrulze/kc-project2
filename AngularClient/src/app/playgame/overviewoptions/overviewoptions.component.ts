import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';
import { UserService } from 'src/app/_services/observables/user.service';
import { OverviewService } from 'src/app/_services/observables/overview.service';

@Component({
  selector: 'app-overviewoptions',
  templateUrl: './overviewoptions.component.html',
  styleUrls: ['./overviewoptions.component.css']
})
export class OverviewoptionsComponent implements OnInit {
  dbndProfText = '';
  showSpinner = true;
  characterSelected = false;
  overviews: any = [];
  userId: string;

  @Input() currentGameID: string;
  @Input() currentClientID: string;
  
  constructor(public dbnd: DbndService, public user: UserService) {
    this.user.userId$.subscribe( id => this.userId = id );
  }

  async ngOnInit() {
    this.populateOverviews();
    console.log("THIS IS THE CURRENT CLIENT: " + this.currentClientID);
    console.log("THIS IS THE CURRENT GAME: " + this.currentGameID);
    }
    
    async populateOverviews() {
      this.dbnd.getGameOverviews$(this.currentClientID, this.currentGameID).subscribe( res => {
        console.log(res);
        this.overviews = res;
        this.showSpinner = false;
      });
    }

}
