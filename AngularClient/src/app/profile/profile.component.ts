import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth/auth.service';
import { DbndService } from '../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs'

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(public auth: AuthService, public dbnd: DbndService) { }

  dbndProfText: string = "";

  async ngOnInit() {
    /*this.dbnd.getId$().subscribe((res: Response) => {
      this.dbnd.getUser$(res["id"]).subscribe( (res: Response) => {
        this.dbndProfText = JSON.stringify(res);
      })
    })*/

    this.dbnd.getUser$(await this.auth.getClientId()).subscribe( (res: Response) => {
      this.dbndProfText = JSON.stringify(res);
    });
  }

}