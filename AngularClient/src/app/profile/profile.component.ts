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

  ngOnInit() {
    this.dbnd.getId$().subscribe( (res: Response) => {
      var guid = res["id"];
      document.getElementById("idDiv").innerHTML = `Id: ${guid}`;
    });
  }

}