import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { IdBase } from '../models/id-base.model';
import { Student } from '../models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentCrudService {
  private deleteListSource = new BehaviorSubject<IdBase[]>([]);
  deleteList = this.deleteListSource.asObservable();

  constructor(private http: HttpClient) { }

  list(): any {
    return this.http.get<Student[]>('https://localhost:7187/Student/List');
  }

  delete(body: IdBase[]): any {
    return this.http.post<IdBase[]>('https://localhost:7187/Student/Delete', body)
  }

  passList(list: IdBase[]): void {
    this.deleteListSource.next(list);
  }
}
