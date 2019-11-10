import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CharacteroptionsComponent } from './characteroptions.component';

describe('CharacteroptionsComponent', () => {
  let component: CharacteroptionsComponent;
  let fixture: ComponentFixture<CharacteroptionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CharacteroptionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CharacteroptionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
