import { Component, OnInit, ViewChild } from '@angular/core';
import { Student } from 'src/app/models/entity-models/student.model';
import { Subject } from 'src/app/models/entity-models/subject.model';
import { EventBusService } from 'src/app/services/event-bus.service';
import { StudentCrudService } from 'src/app/services/student-crud.service';
import { SubjectCrudService } from 'src/app/services/subject-crud.service';
import { ValidationService } from 'src/app/services/validation.service';

@Component({
  selector: '[app-add-course-row]',
  templateUrl: './add-course-row.component.html',
  styleUrls: ['./add-course-row.component.css']
})
export class AddCourseRowComponent implements OnInit {
  @ViewChild('subjectMultiselect') subjectMultiselect: any;
  @ViewChild('studentMultiselect') studentMultiselect: any;
  name: string = '';
  description: string = '';
  isPartFunded: boolean = false;

  constructor(
    private eventBus: EventBusService,
    private subjectCrud: SubjectCrudService,
    private studentCrud: StudentCrudService,
    public validation: ValidationService
  ) 
  { }

  ngOnInit(): void { }

  ngAfterViewInit(): void {
    this.subjectCrud.list()
    .subscribe(
      (result: Subject[]) => {
        this.subjectMultiselect.populateCheckboxes(result, 'subject');
      },
      (error: any) => {
        console.log(error);
      }
    )

    this.studentCrud.list()
    .subscribe(
      (result: Student[]) => {
        this.studentMultiselect.populateCheckboxes(result, 'student');
      },
      (error: any) => {
        console.log(error);
      }
    )
  }

  cancelAdd(): void {
    this.eventBus.showHideRow(false);
  }

  inputUpdated(): void {
    console.log(this.name + ' ' + this.description + ' ' + this.isPartFunded);
    if (!this.validation.fieldIsEmpty(this.name) && 
        !this.validation.fieldIsEmpty(this.description) 
      ) 
    {
      this.eventBus.passInput(
        {
          name: this.name,
          description: this.description,
          isPartFunded: this.isPartFunded
        }
      )
    }
    else {
      this.eventBus.passInput(
        {
          name: undefined,
          description: undefined,
          isPartFunded: undefined,
        }
      )
    }
  }
}
