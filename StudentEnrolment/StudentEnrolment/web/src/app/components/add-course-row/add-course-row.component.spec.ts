import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCourseRowComponent } from './add-course-row.component';

describe('AddCourseRowComponent', () => {
  let component: AddCourseRowComponent;
  let fixture: ComponentFixture<AddCourseRowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCourseRowComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCourseRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
