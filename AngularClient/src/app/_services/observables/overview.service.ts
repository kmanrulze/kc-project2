import { Injectable } from '@angular/core';
import { DbndService } from '../dbnd/dbnd.service';
import { AuthService } from '../auth/auth.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { Overview } from 'src/app/_models/overview';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class OverviewService {

  constructor(private dbnd: DbndService, private auth: AuthService, public gameId: string, public userService: UserService) {
    this.updateOverviews();
  }

  private _overviews: BehaviorSubject<Overview[]> = new BehaviorSubject([]);
  public readonly overviews$: Observable<Overview[]> = this._overviews.asObservable();
  private currentId = '';

  public async updateOverviews() {
    this.userService.userId$.subscribe( res => this.currentId = res );
    this.dbnd.getGameOverviews$(this.currentId, this.gameId)
    .subscribe( res => {this._overviews.next(res as Overview[]);
    });
  }
}
