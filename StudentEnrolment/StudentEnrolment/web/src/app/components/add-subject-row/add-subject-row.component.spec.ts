import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSubjectRowComponent } from './add-subject-row.component';

describe('AddSubjectRowComponent', () => {
  let component: AddSubjectRowComponent;
  let fixture: ComponentFixture<AddSubjectRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddSubjectRowComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddSubjectRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
