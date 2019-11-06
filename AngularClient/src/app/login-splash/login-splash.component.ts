import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth/auth.service';

@Component({
  selector: 'app-login-splash',
  templateUrl: './login-splash.component.html',
  styleUrls: ['./login-splash.component.css']
})
export class LoginSplashComponent implements OnInit {

  constructor(private auth: AuthService) { }

  ngOnInit() {
  }

}
