import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/_services/auth/auth.service';
import { DbndService } from 'src/app/_services/dbnd/dbnd.service';
import { GameService } from 'src/app/_services/observables/game.service';
import { NgForm } from '@angular/forms';
import { Game } from 'src/app/_models/game';
import { UserService } from 'src/app/_services/observables/user.service';

@Component({
  selector: 'app-newtable',
  templateUrl: './newtable.component.html',
  styleUrls: ['./newtable.component.css']
})
export class NewtableComponent implements OnInit {

  userId: string;

  constructor(public user: UserService, public dbnd: DbndService, public gameService: GameService) { }

  ngOnInit() {
  }

  async onSubmit(GameForm: NgForm) {
    console.log(GameForm.value);

    this.user.userId$.subscribe( id => this.userId = id );
    let game: Game = new Game(GameForm.value.GameName, this.userId);
    console.log(game);

    this.dbnd.createGame$(this.userId, game).subscribe(createRes => {
      console.log(createRes);
      // Handle response here: success, failure. Suggest creating alert or third message text idk
      GameForm.resetForm();
      this.gameService.updateGames();
    });
  }  
}
