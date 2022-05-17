import { Component } from '@angular/core';
import { EventBusService } from './services/event-bus.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title: string = 'Student Enrolment';
  isStudent: boolean = false;
  isCourse: boolean = false;
  isSubject: boolean = false;

  constructor(private eventBus: EventBusService) {
    this.eventBus.isStudent.subscribe(student => this.isStudent = student);
    this.eventBus.isCourse.subscribe(course => this.isCourse = course);
    this.eventBus.isSubject.subscribe(subject => this.isSubject = subject);
  }
}
