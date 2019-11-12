import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrenttablesComponent } from './currenttables.component';

describe('CurrenttablesComponent', () => {
  let component: CurrenttablesComponent;
  let fixture: ComponentFixture<CurrenttablesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CurrenttablesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrenttablesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
