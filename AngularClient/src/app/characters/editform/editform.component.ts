import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-editform',
  templateUrl: './editform.component.html',
  styleUrls: ['../characters.component.css']
})
export class EditFormComponent implements OnInit {

  constructor(public auth: AuthService, public dbnd: DbndService) { }

  ngOnInit() {
  }

}
