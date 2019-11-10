import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GameoptionsComponent } from './gameoptions.component';

describe('GameoptionsComponent', () => {
  let component: GameoptionsComponent;
  let fixture: ComponentFixture<GameoptionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GameoptionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GameoptionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
