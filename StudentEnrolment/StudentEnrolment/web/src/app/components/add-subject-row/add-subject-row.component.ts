import { Component, OnInit, ViewChild } from '@angular/core';
import { Course } from 'src/app/models/course.model';
import { CourseCrudService } from 'src/app/services/course-crud.service';
import { EventBusService } from 'src/app/services/event-bus.service';

@Component({
  selector: '[app-add-subject-row]',
  templateUrl: './add-subject-row.component.html',
  styleUrls: ['./add-subject-row.component.css']
})
export class AddSubjectRowComponent implements OnInit {
  courseList: Course[] = [];
  @ViewChild('courseMultiselect') multiselect: any;

  constructor(
    private eventBus: EventBusService,
    private courseCrud: CourseCrudService
  ) 
  { 

  }

  ngOnInit(): void {
  }

  cancelAdd() {
    this.eventBus.showHideRow(false);
  }

  ngAfterViewInit(): void {
    this.courseCrud.list()
    .subscribe(
      (result: Course[]) => {
        this.multiselect.populateCheckboxes(result, 'course');
      },
      (error: any) => {
        console.log(error);
      }
    )
  }
}

