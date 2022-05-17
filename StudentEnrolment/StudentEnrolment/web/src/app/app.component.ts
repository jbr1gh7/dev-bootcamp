import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title: string = 'Student Enrolment';
  isStudent: boolean;
  isCourse: boolean;
  isSubject: boolean;

  constructor() {
    this.isStudent = true;
    this.isCourse = false;
    this.isSubject = false;
  }
}
