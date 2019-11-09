import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-currenttables',
  templateUrl: './currenttables.component.html',
  styleUrls: ['./currenttables.component.css']
})
export class CurrenttablesComponent implements OnInit {
  dbndProfText = '';
  showSpinner = true;
  constructor(public auth: AuthService, public dbnd: DbndService) { }

  async ngOnInit() {

    this.dbnd.getUser$(await this.auth.getClientId())
      .subscribe( (res: Response) => {this.dbndProfText = JSON.stringify(res);
                                      this.showSpinner = false;
      });
    }

}
