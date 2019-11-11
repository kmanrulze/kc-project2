import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth/auth.service';
import { DbndService } from '../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';
import { UserService } from '../_services/observables/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  userId: string;

  constructor(public dbnd: DbndService, public user: UserService) { 
    user.userId$.subscribe( id => this.userId = id );
  }

  dbndProfText = 'test';

  async ngOnInit() {
    /*this.dbnd.getId$().subscribe((res: Response) => {
      this.dbnd.getUser$(res["id"]).subscribe( (res: Response) => {
        this.dbndProfText = JSON.stringify(res);
      })
    })*/

      this.dbndProfText = JSON.stringify(this.userId);
  }

}
