import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FamiliesByPersonComponent } from './families-by-person.component';

describe('FamiliesByPersonComponent', () => {
  let component: FamiliesByPersonComponent;
  let fixture: ComponentFixture<FamiliesByPersonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FamiliesByPersonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FamiliesByPersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
