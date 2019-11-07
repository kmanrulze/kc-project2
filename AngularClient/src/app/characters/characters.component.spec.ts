import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from "@angular/router/testing";
import { Router } from "@angular/router";
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { NgbPaginationModule, NgbModule } from '@ng-bootstrap/ng-bootstrap'

import { CharactersComponent } from './characters.component';
import { FormsModule } from '@angular/forms';

describe('CharactersComponent', () => {
  let component: CharactersComponent;
  let fixture: ComponentFixture<CharactersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule.withRoutes([
          {
            path: "",
            component: BlankComponent
          }, {
            path: "login-splash",
            component: BlankComponent
          }]),
        HttpClientTestingModule,
        NgbPaginationModule,
        FormsModule
      ],
      declarations: [CharactersComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CharactersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

class BlankComponent {

}
