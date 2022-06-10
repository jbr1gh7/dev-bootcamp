import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Course } from '../models/entity-models/course.model';
import { IdBase } from '../models/id-base.model';
import { CourseDto } from '../models/dto-models/course-dto.model';

@Injectable({
  providedIn: 'root'
})
export class CourseCrudService {
  deleteList: IdBase[] = [];

  constructor(private http: HttpClient) { }

  create(entity: CourseDto): any {
    return this.http.post<CourseDto>('https://localhost:7187/Course/Create', entity);
  }

  list(): any {
    return this.http.get<Course[]>('https://localhost:7187/Course/List');
  }

  delete(): any {
    return this.http.post<IdBase[]>('https://localhost:7187/Course/Delete', this.deleteList)
  }

  pushToDeleteList(idBase: IdBase): void {
    this.deleteList.push(idBase);
    console.log(this.deleteList);
  }

  removeFromDeleteList(idBase: IdBase): void {
    this.deleteList = this.deleteList.filter((item) => item.id !== idBase.id); 
    console.log(this.deleteList);
  }
}
