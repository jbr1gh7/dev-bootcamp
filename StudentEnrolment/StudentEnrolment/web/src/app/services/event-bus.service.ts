import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventBusService {
  private studentSource = new BehaviorSubject<boolean>(true);
  isStudent = this.studentSource.asObservable();

  private courseSource = new BehaviorSubject<boolean>(false);
  isCourse = this.courseSource.asObservable();

  private subjectSource = new BehaviorSubject<boolean>(false);
  isSubject = this.subjectSource.asObservable();

  constructor() {
  }

  showHideStudent(isStudent: boolean): void {
    this.studentSource.next(isStudent);
  }

  showHideCourse(isCourse: boolean): void {
    this.courseSource.next(isCourse);
  }

  showHideSubject(isSubject: boolean): void {
    this.subjectSource.next(isSubject);
  }

}
