import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';
import { Character } from '../../_models/character';
@Component({
  selector: 'app-editform',
  templateUrl: './editform.component.html',
  styleUrls: ['../characters.component.css']
})
export class EditFormComponent implements OnInit {
  characterModel = new Character();
  constructor(public auth: AuthService, public dbnd: DbndService) { }

  ngOnInit() {
  }

}
