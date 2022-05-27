import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from '../models/subject.model';

@Injectable({
  providedIn: 'root'
})
export class SubjectCrudService {

  constructor(private http: HttpClient) { }

  list(): any {
    return this.http.get<Subject[]>('https://localhost:7187/Subject/List');
  }
}
