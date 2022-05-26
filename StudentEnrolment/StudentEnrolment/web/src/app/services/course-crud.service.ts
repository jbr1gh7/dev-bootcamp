import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Course } from '../models/course.model';

@Injectable({
  providedIn: 'root'
})
export class CourseCrudService {

  constructor(private http: HttpClient) { }

  list(): any {
    return this.http.get<Course[]>('https://localhost:7187/Course/List');
  }
}