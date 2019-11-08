import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-listcharacters',
  templateUrl: './listcharacters.component.html',
  styleUrls: ['./listcharacters.component.css']
})
export class ListcharactersComponent implements OnInit {

  constructor(public auth: AuthService, public dbnd: DbndService) { }

  ngOnInit() {
  }

}
