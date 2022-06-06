import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddStudentRowComponent } from './add-student-row.component';

describe('AddStudentRowComponent', () => {
  let component: AddStudentRowComponent;
  let fixture: ComponentFixture<AddStudentRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddStudentRowComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddStudentRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
