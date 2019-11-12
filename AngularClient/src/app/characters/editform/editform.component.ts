import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';
import { Observable } from 'rxjs';
import { Character } from '../../_models/character';
import { CharacterService } from '../../_services/observables/character.service';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/_services/observables/user.service';
@Component({
  selector: 'app-editform',
  templateUrl: './editform.component.html',
  styleUrls: ['../characters.component.css']
})
export class EditFormComponent implements OnInit {

  @Input() character: Character;
  @Input() characterId: string;
  @Output() newFormMode = new EventEmitter<string>();

  userId: string;
  
  constructor(public dbnd: DbndService, public user: UserService, private characterService: CharacterService) {
    this.user.userId$.subscribe( id => this.userId = id );
  }

  ngOnInit() { }

  async onEditSubmit(Character: NgForm){
    this.dbnd.updateCharacter$( this.userId, this.characterId, this.character ).subscribe( async res => {
      Character.reset();
      this.newFormMode.emit('new');
    });
  }
}
