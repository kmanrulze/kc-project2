import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Character } from 'src/app/_models/character';
import { AuthService } from 'src/app/_services/auth/auth.service';
import { DbndService } from 'src/app/_services/dbnd/dbnd.service';
import { CharacterService } from 'src/app/_services/observables/character.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-deletecharacter',
  templateUrl: './deletecharacter.component.html',
  styleUrls: ['./deletecharacter.component.css']
})
export class DeletecharacterComponent implements OnInit {

  @Input() characterId: string;
  @Output() newFormMode = new EventEmitter<string>();

  constructor(public auth: AuthService, public dbnd: DbndService, private characterService: CharacterService) { }

  ngOnInit() { }

  async onSubmitDelete() {
    await this.dbnd.deleteCharacter$( await this.auth.getClientId(), this.characterId ).subscribe( async res => {
      this.newFormMode.emit('new');
    });
  }
}
