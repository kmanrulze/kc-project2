import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';
import { UserService } from 'src/app/_services/observables/user.service';

@Component({
  selector: 'app-overviewoptions',
  templateUrl: './overviewoptions.component.html',
  styleUrls: ['./overviewoptions.component.css']
})
export class OverviewoptionsComponent implements OnInit {
  dbndProfText = '';
  showSpinner = true;
  characterSelected = false;
  userId: string;
  
  constructor(public dbnd: DbndService, public user: UserService) {
    this.user.userId$.subscribe( id => this.userId = id );
  }

  async ngOnInit() {

    this.getUser();
    this.populateOverviews();

    }
    async populateOverviews() {
      this.overviewService.overviews$.subscribe( async res => {
        this.showSpinner = false;
        this.overviews = res;
      });
    }

    async getUser() {
      this.dbnd.getUser$(await this.auth.getClientId())
      .subscribe( (res: Response) => {this.dbndProfText = JSON.stringify(res);
                                      this.showSpinner = false;
      });
    }

}
