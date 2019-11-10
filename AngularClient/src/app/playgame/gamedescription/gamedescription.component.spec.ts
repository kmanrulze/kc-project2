import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GamedescriptionComponent } from './gamedescription.component';

describe('GamedescriptionComponent', () => {
  let component: GamedescriptionComponent;
  let fixture: ComponentFixture<GamedescriptionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GamedescriptionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GamedescriptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
