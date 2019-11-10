import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OverviewoptionsComponent } from './overviewoptions.component';

describe('OverviewoptionsComponent', () => {
  let component: OverviewoptionsComponent;
  let fixture: ComponentFixture<OverviewoptionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OverviewoptionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OverviewoptionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
