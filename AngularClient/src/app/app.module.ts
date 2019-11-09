import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms'
import { NgbModule } from '@ng-bootstrap/ng-bootstrap'
import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { LoginSplashComponent } from './login-splash/login-splash.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ProfileComponent } from './profile/profile.component';
import { CharactersComponent } from './characters/characters.component';
import { TablesComponent } from './tables/tables.component';
import { NewFormComponent } from './characters/newform/newform.component';
import { NewtableComponent } from './tables/newtable/newtable.component';
import { ListCharactersComponent } from './characters/listcharacters/listcharacters.component';
import { LoadingSpinComponent } from './ui/loading-spin/loading-spin.component';
import { EditFormComponent } from './characters/editform/editform.component';
import { JoinTableComponent } from './tables/jointable/jointable.component';

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
    ListCharactersComponent,
    LoadingSpinComponent,
    EditFormComponent,
    JoinTableComponent,
  ],
  imports: [
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
