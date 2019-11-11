import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';
import { Character } from '../../_models/character';


@Component({
  selector: 'app-newform',
  templateUrl: './newform.component.html',
  styleUrls: ['../characters.component.css']
})
export class NewFormComponent implements OnInit {
  dbndProfText: string = "";
  characterModel = new Character('', '');



  onSubmit(){
    console.log('submit')};

  constructor(public auth: AuthService, public dbnd: DbndService) { }

  async ngOnInit() {

    this.dbnd.getUser$(await this.auth.getClientId()).subscribe( (res: Response) => {
      this.dbndProfText = JSON.stringify(res);
    });



  }
}
