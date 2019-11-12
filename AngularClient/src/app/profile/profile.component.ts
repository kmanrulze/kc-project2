import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth/auth.service';
import { DbndService } from '../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';
import { UserService } from '../_services/observables/user.service';
import { Client } from '../_models/client';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  userId: string;

  constructor(public dbnd: DbndService, public user: UserService) {
    user.userId$.subscribe( id => this.userId = id );

    this.userInfo = this.dbnd.getUser$(this.userId)
      .subscribe( res => { console.log('res ' + JSON.stringify( res )); } );
  }

  userInfo: any;
  dbndProfText = 'test';

  async ngOnInit() {
    /*this.dbnd.getId$().subscribe((res: Response) => {
      this.dbnd.getUser$(res["id"]).subscribe( (res: Response) => {
        this.dbndProfText = JSON.stringify(res);
      })
    })*/
    console.log('userid ' + this.userId);
    this.userInfo = this.dbnd.getUser$(this.userId)
      .subscribe( res => { console.log(res); } );

    this.dbndProfText = JSON.stringify( this.userId );
  }

}
