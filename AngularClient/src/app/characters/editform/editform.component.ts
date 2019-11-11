import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';
import { Character } from '../../_models/character';
import { CharacterService } from '../../_services/observables/character.service';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-editform',
  templateUrl: './editform.component.html',
  styleUrls: ['../characters.component.css']
})
export class EditFormComponent implements OnInit {

  @Input() character: Character;
  @Input() characterId: string;
  @Output() newFormMode = new EventEmitter<string>();

  constructor(public auth: AuthService, public dbnd: DbndService, private characterService: CharacterService) { }

  ngOnInit() { }

  async onEditSubmit(Character: NgForm) {
    this.dbnd.updateCharacter$( await this.auth.getClientId(), this.characterId, this.character ).subscribe( async res => {
      Character.reset();
      this.newFormMode.emit('new');
    });
  }
}
