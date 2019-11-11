import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/_services/auth/auth.service';
import { DbndService } from 'src/app/_services/dbnd/dbnd.service';
import { GameService } from 'src/app/_services/observables/game.service';
import { NgForm } from '@angular/forms';
import { Game } from 'src/app/_models/game';

@Component({
  selector: 'app-newtable',
  templateUrl: './newtable.component.html',
  styleUrls: ['./newtable.component.css']
})
export class NewtableComponent implements OnInit {

  constructor(public auth: AuthService, public dbnd: DbndService, public gameService: GameService) { }

  ngOnInit() {
  }

  async onSubmit(GameForm: NgForm) {
    console.log(GameForm.value);

    const id = await this.auth.getClientId();
    const game: Game = new Game(GameForm.value.GameName, id);
    console.log(game);

    this.dbnd.createGame$(id, game).subscribe(createRes => {
      console.log(createRes);
      // Handle response here: success, failure. Suggest creating alert or third message text idk
      GameForm.resetForm();
      this.gameService.updateGames();
    });
  }
}
