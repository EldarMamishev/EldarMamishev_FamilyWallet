import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FamilyWithPeopleComponent } from './family-with-people.component';

describe('FamilyWithPeopleComponent', () => {
  let component: FamilyWithPeopleComponent;
  let fixture: ComponentFixture<FamilyWithPeopleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FamilyWithPeopleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FamilyWithPeopleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
