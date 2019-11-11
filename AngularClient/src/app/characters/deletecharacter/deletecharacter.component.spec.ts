import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletecharacterComponent } from './deletecharacter.component';

describe('DeletecharacterComponent', () => {
  let component: DeletecharacterComponent;
  let fixture: ComponentFixture<DeletecharacterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeletecharacterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeletecharacterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
