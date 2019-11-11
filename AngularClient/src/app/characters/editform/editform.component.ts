import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';
import { Character } from '../../_models/character';
import { CharacterService } from '../../_services/observables/character.service';
@Component({
  selector: 'app-editform',
  templateUrl: './editform.component.html',
  styleUrls: ['../characters.component.css']
})
export class EditFormComponent implements OnInit {
  characterModel = new Character('', '');
  targetID = '';
  constructor(public auth: AuthService, public dbnd: DbndService, private data: CharacterService) { }

  ngOnInit() {
    // this.data.currentTargetID.subscribe(targetID => this.targetID = targetID);
  }

  // currCharacter: Character = this.dbnd.getCharacter$(this.auth.clientId, this.targetID);

  onSubmitHandler() {
    // this.dbnd.updateCharacter$( this.auth.clientId, this.targetID, this.characterModel );
  }

}
