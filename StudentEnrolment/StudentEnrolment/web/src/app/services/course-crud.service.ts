import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Course } from '../models/course.model';
import { IdBase } from '../models/id-base.model';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';

@Injectable({
  providedIn: 'root'
})
export class CourseCrudService {
  private deleteListSource = new BehaviorSubject<IdBase[]>([]);
  deleteList = this.deleteListSource.asObservable();

  constructor(private http: HttpClient) { }

  list(): any {
    return this.http.get<Course[]>('https://localhost:7187/Course/List');
  }

  delete(body: IdBase[]): any {
    return this.http.post<IdBase[]>('https://localhost:7187/Student/Delete', body)
  }

  passList(list: IdBase[]): void {
    this.deleteListSource.next(list);
  }
}
