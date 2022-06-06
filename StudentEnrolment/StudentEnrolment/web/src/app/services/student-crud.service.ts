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

  delete(): any {
    return this.http.post<IdBase[]>('https://localhost:7187/Student/Delete', this.deleteListSource.getValue())
  }

  pushToDeleteList(idBase: IdBase): void {
    this.deleteListSource.getValue().push(idBase);
    console.log(this.deleteListSource.getValue());
  }

  removeFromDeleteList(idBase: IdBase): void {
    let updatedList = this.deleteListSource.getValue();
    updatedList = updatedList.filter((item) => item.id !== idBase.id); 

    this.deleteListSource.next(updatedList);
    console.log(this.deleteListSource.getValue());
  }
}
