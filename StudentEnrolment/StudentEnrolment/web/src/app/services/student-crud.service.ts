import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IdBase } from '../models/id-base.model';
import { Student } from '../models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentCrudService {
  deleteList: IdBase[] = [];

  constructor(private http: HttpClient) { }

  list(): any {
    return this.http.get<Student[]>('https://localhost:7187/Student/List');
  }

  delete(): any {
    return this.http.post<IdBase[]>('https://localhost:7187/Student/Delete', this.deleteList)
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
