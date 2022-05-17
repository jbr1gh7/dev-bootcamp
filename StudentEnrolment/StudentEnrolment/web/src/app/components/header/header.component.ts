import { Component, OnInit } from '@angular/core';
import { EventBusService } from 'src/app/services/event-bus.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  isStudent: boolean = false;
  isCourse: boolean = false;
  isSubject: boolean = false;

  constructor(private eventBus: EventBusService) { }

  ngOnInit(): void {
    this.eventBus.isStudent.subscribe(student => this.isStudent = student);
    this.eventBus.isCourse.subscribe(course => this.isCourse = course);
    this.eventBus.isSubject.subscribe(subject => this.isSubject = subject);
  }

  showStudents(): void {
    this.eventBus.showHideCourse(false);
    this.eventBus.showHideSubject(false);
    this.eventBus.showHideStudent(true);
  }

  showCourses(): void {
    this.eventBus.showHideStudent(false);
    this.eventBus.showHideSubject(false);
    this.eventBus.showHideCourse(true);
  }

  showSubjects(): void {
    this.eventBus.showHideStudent(false);
    this.eventBus.showHideCourse(false);
    this.eventBus.showHideSubject(true);
  }


}
