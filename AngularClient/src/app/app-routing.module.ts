import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { AuthGuard } from './_guards/auth/auth.guard';
import { InterceptorService } from './_services/interceptor/interceptor.service';

import { ProfileComponent } from './profile/profile.component';
import { TablesComponent } from './tables/tables.component';
import { LoginSplashComponent } from './login-splash/login-splash.component';
import { CharactersComponent } from './characters/characters.component';
import { NewFormComponent } from './characters/newform/newform.component';

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
