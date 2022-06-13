import { Component, OnInit, ViewChild } from '@angular/core';
import { Course } from 'src/app/models/entity-models/course.model';
import { CourseCrudService } from 'src/app/services/course-crud.service';
import { EventBusService } from 'src/app/services/event-bus.service';
import { ValidationService } from 'src/app/services/validation.service';

@Component({
  selector: '[app-add-subject-row]',
  templateUrl: './add-subject-row.component.html',
  styleUrls: ['./add-subject-row.component.css']
})
export class AddSubjectRowComponent implements OnInit {
  courseList: Course[] = [];
  @ViewChild('courseMultiselect') multiselect: any;
  name: string = '';
  description: string = '';

  constructor(
    private eventBus: EventBusService,
    private courseCrud: CourseCrudService,
    public validation: ValidationService
  ) 
  { }

  ngOnInit(): void { }

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

  cancelAdd(): void {
    this.eventBus.showHideRow(false);
  }

  inputUpdated() {
    console.log(this.name + ' ' + this.description);
    if (!this.validation.fieldIsEmpty(this.name) && 
        !this.validation.fieldIsEmpty(this.description)
      ) 
    {
      this.eventBus.passInput(
        {
          name: this.name,
          description: this.description,
        }
      )
    }
    else {
      this.eventBus.passInput(
        {
          name: undefined,
          description: undefined,
        }
      )
    }
  }
}

