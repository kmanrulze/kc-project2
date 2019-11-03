import { Component, OnInit } from '@angular/core';
import { AuthService } from './_services/auth/auth.service';
import { DbndService } from './_services/dbnd/dbnd.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private auth: AuthService, private dbnd: DbndService) {}

  ngOnInit() {
    this.auth.localAuthSetup();
    this.auth.handleAuthCallback();
  }

}