import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { JoinTableComponent } from './jointable.component';

describe('JointableComponent', () => {
  let component: JoinTableComponent;
  let fixture: ComponentFixture<JoinTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JoinTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JoinTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
