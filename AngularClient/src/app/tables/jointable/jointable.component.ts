import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-jointable',
  templateUrl: './jointable.component.html',
  styleUrls: ['../../characters/characters.component.css']
})
export class JoinTableComponent implements OnInit {

  constructor(public auth: AuthService, public dbnd: DbndService) { }

  ngOnInit() {
  }

}
