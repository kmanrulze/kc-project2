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
    MonsterComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgbModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
