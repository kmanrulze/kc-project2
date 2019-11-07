import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import {RouterTestingModule} from "@angular/router/testing";
import {Router} from "@angular/router";
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { LoginSplashComponent } from './login-splash.component';

describe('LoginSplashComponent', () => {
  let component: LoginSplashComponent;
  let fixture: ComponentFixture<LoginSplashComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule.withRoutes([
        {
          path: "",
          component: BlankComponent
        }, {
          path:"login-splash",
          component: BlankComponent
        }]), 
        HttpClientTestingModule],
      declarations: [ LoginSplashComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginSplashComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

class BlankComponent {

}
