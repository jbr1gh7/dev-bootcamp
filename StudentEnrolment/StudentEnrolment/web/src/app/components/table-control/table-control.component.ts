import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CourseStudent } from 'src/app/models/course-student.model';
import { Course } from 'src/app/models/course.model';
import { IdBase } from 'src/app/models/id-base.model';
import { Student } from 'src/app/models/student.model';
import { CourseStudentDto } from 'src/app/models/course-student-dto.model';
import { CourseCrudService } from 'src/app/services/course-crud.service';
import { EventBusService } from 'src/app/services/event-bus.service';
import { StudentCrudService } from 'src/app/services/student-crud.service';
import { SubjectCrudService } from 'src/app/services/subject-crud.service';
import { StudentDto } from 'src/app/models/student-dto.model';

@Component({
  selector: 'app-table-control',
  templateUrl: './table-control.component.html',
  styleUrls: ['./table-control.component.css']
})
export class TableControlComponent implements OnInit {
  deleteList: IdBase[] = [];
  selectionList: any[] = [];
  inputObject: any = undefined;

  constructor(
    private studentCrud: StudentCrudService,
    private courseCrud: CourseCrudService,
    private subjectCrud: SubjectCrudService,
    private eventBus: EventBusService,
    private router: Router
  ) 
  {

  }

  ngOnInit(): void {
    this.eventBus.selectionList.subscribe((list) => this.selectionList = list);
    this.eventBus.input.subscribe((input) => this.inputObject = input);  
  }

  add(): void {
    this.eventBus.showHideRow(true);
  }

  saveDelete(): void {
    let crud;
    switch(this.router.url) {
      case '/Students':
        crud = this.studentCrud;
        break;
      case '/Courses':
        crud = this.courseCrud;
        break;
      case '/Subjects':
        crud = this.subjectCrud;
        break;
      default:
        return;
    }

    if (crud.deleteList.length == 0)
      return;

    crud.delete()
    .subscribe(
      (result: any) => {
        console.log(result);
      },
      (error: any) => {
        console.log(error);
      }
    )
  }

  formStudentEntity(): StudentDto {
    let courses = [];

    for (let i = 0; i < this.selectionList.length; i++) {
      let courseId = this.selectionList[i].item_id;

      courses.push(
        new CourseStudentDto(
          courseId,
          null,
        )
      );
    }

    return new StudentDto(
      null, 
      this.inputObject.firstName, 
      this.inputObject.lastName, 
      courses
    );
  }

  saveAdd(): void {
    switch(this.router.url) {
      case '/Students':
        this.studentCrud.create(this.formStudentEntity())
        .subscribe(
          (result: any) => {
            console.log(result);
          },
          (error: any) => {
            console.log(error);
          }
        );
        break;
      case '/Courses':
        //crud = this.courseCrud;
        break;
      case '/Subjects':
        //crud = this.subjectCrud;
        break;
      default:
        return;
    }
  }

  save(): void {
    this.saveDelete();
    this.saveAdd();
  }
}
