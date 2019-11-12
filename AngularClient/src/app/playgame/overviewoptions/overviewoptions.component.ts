import { Component, OnInit } from '@angular/core';
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
  
  constructor(public dbnd: DbndService, public user: UserService, public overviewService: OverviewService) {
    this.user.userId$.subscribe( id => this.userId = id );
  }

  async ngOnInit() {

    this.populateOverviews();
    }
    
    async populateOverviews() {
      this.overviewService.overviews$.subscribe( async res => {
        this.showSpinner = false;
        this.overviews = res;
      });
    }

}
