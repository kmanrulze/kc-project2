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
import { NewtableComponent } from './tables/newtable/newtable.component';
import { ListcharactersComponent } from './characters/listcharacters/listcharacters.component';
import { MonsterComponent } from './monster/monster.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSliderModule } from '@angular/material/slider';

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
    NewtableComponent,
    ListcharactersComponent,
    MonsterComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgbModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatSliderModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
