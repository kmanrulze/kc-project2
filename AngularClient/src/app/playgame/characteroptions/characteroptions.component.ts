import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';
import { UserService } from 'src/app/_services/observables/user.service';

@Component({
  selector: 'app-characteroptions',
  templateUrl: './characteroptions.component.html',
  styleUrls: ['./characteroptions.component.css']
})
export class CharacteroptionsComponent implements OnInit {
  dbndProfText = '';
  showSpinner = true;
  characterSelected = false;
  userId: string;
  
  constructor(public dbnd: DbndService, public user: UserService) { 
    this.user.userId$.subscribe( id => this.userId = id );
  }

  async ngOnInit() {

    /*this.dbnd.getUser$(this.userId)
       .subscribe( (res: Response) => {this.dbndProfText = JSON.stringify(res);
                                      this.showSpinner = false;
      });*/
  }

}
