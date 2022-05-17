import { TestBed } from '@angular/core/testing';

import { CourseCrudService } from './course-crud.service';

describe('CourseCrudService', () => {
  let service: CourseCrudService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CourseCrudService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
