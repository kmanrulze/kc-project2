import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../../_services/auth/auth.service';
import { DbndService } from '../../_services/dbnd/dbnd.service';

import { CharacterService } from '../../_services/observables/character.service';

@Component({
  selector: 'app-listcharacters',
  templateUrl: './listcharacters.component.html',
  styleUrls: ['./listcharacters.component.css']
})
export class ListcharactersComponent implements OnInit {
    showSpinner = true;

    @Output() newFormModeWithId = new EventEmitter<{newFormMode: string, characterId: string}>();
    @Output() newMode = new EventEmitter<string>();

  constructor(public auth: AuthService, public dbnd: DbndService, public characterService: CharacterService) { }

  async onSubmit() { }

  async ngOnInit() {
    // Subscribe to the observable and set showSpinner to false when there is a value.
    await this.characterService.characters$.subscribe( res => {
      this.showSpinner = false;
    });
  }

  onClickTableHandler(characterId: string) {
    this.newMode.emit(characterId);
  }

  onClickEditHandler(characterId: string) {
    const newFormMode = 'edit';
    this.newFormModeWithId.emit({newFormMode, characterId});
  }

  onClickDelete(characterId: string) {
    const newFormMode = 'delete';
    this.newFormModeWithId.emit({newFormMode, characterId});
  }
}
