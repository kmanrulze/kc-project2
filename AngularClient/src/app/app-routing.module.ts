import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { AuthGuard } from './_guards/auth/auth.guard';
import { InterceptorService } from './_services/interceptor/interceptor.service';

import { ProfileComponent } from './profile/profile.component';
import { TablesComponent } from './tables/tables.component';
import { LoginSplashComponent } from './login-splash/login-splash.component';

import { CharactersComponent } from './characters/characters.component';
import { ListcharactersComponent } from './characters/listcharacters/listcharacters.component';
import { NewFormComponent } from './characters/newform/newform.component';
import { EditFormComponent } from './characters/editform/editform.component';

import { JoinTableComponent } from './tables/jointable/jointable.component';
import { CurrenttablesComponent } from './tables/currenttables/currenttables.component';
import { EdittableComponent } from './tables/edittable/edittable.component';

import { PlaygameComponent } from './playgame/playgame.component';
import { CharacteroptionsComponent } from './playgame/characteroptions/characteroptions.component';
import { OverviewoptionsComponent } from './playgame/overviewoptions/overviewoptions.component';
import { GameoptionsComponent } from './playgame/gameoptions/gameoptions.component';


const routes: Routes = [
  { path: '', redirectTo: 'login-splash', pathMatch: 'full' },
  {
    path: 'login-splash',
    component: LoginSplashComponent
  },
  {
    path: 'profile',
    component: ProfileComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'tables',
    component: TablesComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'characters',
    component: CharactersComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'characters/new',
    component: NewFormComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'characters/listcharacters',
    component: ListcharactersComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'characters/edit',
    component: EditFormComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'tables/jointable',
    component: JoinTableComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'tables/currenttables',
    component: CurrenttablesComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'tables/edittable',
    component: EdittableComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'playgame',
    component: PlaygameComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'playgame/characteroptions',
    component: CharacteroptionsComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'playgame/overviewoptions',
    component: OverviewoptionsComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'playgame/gameoptions',
    component: GameoptionsComponent,
    canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: InterceptorService,
      multi: true
    }
  ]
})
export class AppRoutingModule { }
