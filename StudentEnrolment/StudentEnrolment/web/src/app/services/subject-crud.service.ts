import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IdBase } from '../models/id-base.model';
import { SubjectDto } from '../models/subject-dto.model';
import { Subject } from '../models/subject.model';

@Injectable({
  providedIn: 'root'
})
export class SubjectCrudService {
  deleteList: IdBase[] = [];
  
  constructor(private http: HttpClient) { }

  create(entity: SubjectDto): any {
    return this.http.post<SubjectDto>('https://localhost:7187/Subject/Create', entity);
  }

  list(): any {
    return this.http.get<Subject[]>('https://localhost:7187/Subject/List');
  }

  delete(): any {
    return this.http.post<IdBase[]>('https://localhost:7187/Subject/Delete', this.deleteList)
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


