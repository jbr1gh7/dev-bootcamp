import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventBusService {
  private addEventSource = new BehaviorSubject<boolean>(false);
  isAddingEvent = this.addEventSource.asObservable();

  private selectionListSource = new BehaviorSubject<any[]>([]);
  selectionList = this.selectionListSource.asObservable();

  private courseStudentSelectionListSource = new BehaviorSubject<any[]>([]);
  courseStudentSelectionList = this.courseStudentSelectionListSource.asObservable();

  private courseSubjectSelectionListSource = new BehaviorSubject<any[]>([]);
  courseSubjectSelectionList = this.courseSubjectSelectionListSource.asObservable();

  private inputSource = new BehaviorSubject<any>(undefined);
  input = this.inputSource.asObservable();

  constructor() { }

  showHideRow(isAdding: boolean): void {
    this.addEventSource.next(isAdding);
  }

  passSelectionList(selections: any[]): void {
    this.selectionListSource.next(selections);
  }

  passCourseStudentSelectionList(selections: any[]): void {
    this.courseStudentSelectionListSource.next(selections);
  }

  passCourseSubjectSelectionList(selections: any[]): void {
    this.courseSubjectSelectionListSource.next(selections);
  }

  passInput(input: any): void {
    this.inputSource.next(input);
  }
}
