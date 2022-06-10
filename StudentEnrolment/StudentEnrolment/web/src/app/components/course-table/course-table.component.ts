import { Component, OnInit } from '@angular/core';
import { Course } from 'src/app/models/course.model';
import { CourseCrudService } from 'src/app/services/course-crud.service';
import { EventBusService } from 'src/app/services/event-bus.service';

@Component({
  selector: 'app-course-table',
  templateUrl: './course-table.component.html',
  styleUrls: ['./course-table.component.css']
})
export class CourseTableComponent implements OnInit {
  rows: Course[] = [];
  isAdding: boolean = false;

  constructor(
    private eventBus: EventBusService,
    private courseCrud: CourseCrudService
  ) 
  {
    this.eventBus.isAddingEvent.subscribe((adding: boolean) => this.isAdding = adding); 
  }

  ngOnInit(): void {
    this.courseCrud.list()
    .subscribe(
      (result: Course[]) => {
        this.rows = result;
      },
      (error: any) => {
        console.log(error);
      }
    )
  }
}
