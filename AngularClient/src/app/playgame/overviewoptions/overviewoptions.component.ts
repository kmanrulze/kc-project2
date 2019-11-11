import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-overviewoptions',
  templateUrl: './overviewoptions.component.html',
  styleUrls: ['./overviewoptions.component.css']
})
export class OverviewoptionsComponent implements OnInit {
  dbndProfText = '';
  showSpinner = true;
  characterSelected = false;
  dbndOverview = '';
  constructor(public auth: AuthService, public dbnd: DbndService) { }

  async ngOnInit() {

    this.dbnd.getUser$(await this.auth.getClientId())
      .subscribe( (res: Response) => {this.dbndProfText = JSON.stringify(res);
                                      this.showSpinner = false;
      });

    //Need to add on init call to api for overview description here
    this.dbnd.getOverview$(await this.auth.getClientId(), 'gameId', 'overviewId')
      .subscribe( (res: Response) => {this.dbndOverview = JSON.stringify(res);
                                                            this.showSpinner = false;})
    }

}
