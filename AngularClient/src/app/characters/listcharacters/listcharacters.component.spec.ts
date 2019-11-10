import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { Router } from '@angular/router';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { NgbPaginationModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { CharactersComponent } from '../characters.component';
import { FormsModule } from '@angular/forms';
import { NewFormComponent } from '../newform/newform.component';
import { ListcharactersComponent } from './listcharacters.component';

describe('ListcharactersComponent', () => {
  let component: ListcharactersComponent;
  let fixture: ComponentFixture<ListcharactersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule.withRoutes([
          {
            path: '',
            component: BlankComponent
          }, {
            path: 'login-splash',
            component: BlankComponent
          }]),
        HttpClientTestingModule,
        NgbPaginationModule,
        FormsModule
      ],
      declarations: [CharactersComponent, NewFormComponent, ListcharactersComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListcharactersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

class BlankComponent {

}

