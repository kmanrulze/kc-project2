import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'app-welcome-splash',
  templateUrl: './welcome-splash.component.html',
  styleUrls: ['./welcome-splash.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class WelcomeSplashComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
