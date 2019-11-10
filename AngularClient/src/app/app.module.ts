import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';

import { RouterModule, Routes } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { LoginSplashComponent } from './login-splash/login-splash.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ProfileComponent } from './profile/profile.component';
import { CharactersComponent } from './characters/characters.component';
import { TablesComponent } from './tables/tables.component';
import { NewFormComponent } from './characters/newform/newform.component';
import { EditFormComponent } from './characters/editform/editform.component';
import { NewtableComponent } from './tables/newtable/newtable.component';
import { JoinTableComponent } from './tables/jointable/jointable.component';
import { ListcharactersComponent } from './characters/listcharacters/listcharacters.component';
import { LoadingSpinComponent } from './ui/loading-spin/loading-spin.component';
import { MonsterComponent } from './monster/monster.component';
import { CurrenttablesComponent } from './tables/currenttables/currenttables.component';
import { EdittableComponent } from './tables/edittable/edittable.component';
import { NgbdTooltipCustomclass } from './ui/tootip-custom-class/tooltip-customclass';
import { PlaygameComponent } from './playgame/playgame.component';
import { CharacteroptionsComponent } from './playgame/characteroptions/characteroptions.component';
import { OverviewoptionsComponent } from './playgame/overviewoptions/overviewoptions.component';
import { GameoptionsComponent } from './playgame/gameoptions/gameoptions.component';
import { MatSliderModule } from '@angular/material/slider';
import { MatListModule } from '@angular/material/list';
import { GamedescriptionComponent } from './playgame/gamedescription/gamedescription.component';

const appRoutes: Routes = [
  {
    path: 'products',
    component: MonsterComponent,
    data: { title: 'Monster List' }
  },
  { path: '',
    redirectTo: '/monsters',
    pathMatch: 'full'
  }
];

@NgModule({
  declarations: [
    AppComponent,
    LoginSplashComponent,
    NavbarComponent,
    ProfileComponent,
    CharactersComponent,
    TablesComponent,
    LoginSplashComponent,
    NewFormComponent,
    EditFormComponent,
    NewtableComponent,
    JoinTableComponent,
    ListcharactersComponent,
    LoadingSpinComponent,
    MonsterComponent,
    CurrenttablesComponent,
    EdittableComponent,
    NgbdTooltipCustomclass,
    PlaygameComponent,
    CharacteroptionsComponent,
    OverviewoptionsComponent,
    GameoptionsComponent,
    GamedescriptionComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgbModule,
    HttpClientModule,
    MatSliderModule,
    MatListModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
