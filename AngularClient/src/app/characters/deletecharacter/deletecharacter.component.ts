import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Character } from 'src/app/_models/character';
import { AuthService } from 'src/app/_services/auth/auth.service';
import { DbndService } from 'src/app/_services/dbnd/dbnd.service';
import { CharacterService } from 'src/app/_services/observables/character.service';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/_services/observables/user.service';

@Component({
  selector: 'app-deletecharacter',
  templateUrl: './deletecharacter.component.html',
  styleUrls: ['./deletecharacter.component.css']
})
export class DeletecharacterComponent implements OnInit {

  @Input() characterId: string;
  @Output() newFormMode = new EventEmitter<string>();

  userId: string;
  
  constructor(public dbnd: DbndService, public user: UserService, private characterService: CharacterService) { 
    user.userId$.subscribe( id => this.userId = id );
  }

  ngOnInit() { }

  async onSubmitDelete() {
    await this.dbnd.deleteCharacter$( this.userId, this.characterId ).subscribe( async res => {
      this.newFormMode.emit("new");
    });
  }
}
