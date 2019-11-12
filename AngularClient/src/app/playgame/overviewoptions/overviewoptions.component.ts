import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';
import { OverviewService } from 'src/app/_services/observables/overview.service';

@Component({
  selector: 'app-overviewoptions',
  templateUrl: './overviewoptions.component.html',
  styleUrls: ['./overviewoptions.component.css']
})
export class OverviewoptionsComponent implements OnInit {
  dbndProfText = '';
  showSpinner = true;
  overviewSelected = false;
  overviews: any = [];


  constructor(public auth: AuthService, public dbnd: DbndService, public overviewService: OverviewService) { }

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
