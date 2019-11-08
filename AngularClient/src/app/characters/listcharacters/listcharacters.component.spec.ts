import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListcharactersComponent } from './listcharacters.component';

describe('ListcharactersComponent', () => {
  let component: ListcharactersComponent;
  let fixture: ComponentFixture<ListcharactersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListcharactersComponent ]
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
