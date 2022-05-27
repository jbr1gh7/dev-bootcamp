import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Student } from '../models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentCrudService {

  constructor(private http: HttpClient) { }

  list(): any {
    return this.http.get<Student[]>('https://localhost:7187/Student/List');
  }
}
