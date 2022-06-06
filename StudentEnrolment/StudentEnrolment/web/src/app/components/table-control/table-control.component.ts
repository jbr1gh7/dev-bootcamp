import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IdBase } from 'src/app/models/id-base.model';
import { CourseCrudService } from 'src/app/services/course-crud.service';
import { EventBusService } from 'src/app/services/event-bus.service';
import { StudentCrudService } from 'src/app/services/student-crud.service';
import { SubjectCrudService } from 'src/app/services/subject-crud.service';

@Component({
  selector: 'app-table-control',
  templateUrl: './table-control.component.html',
  styleUrls: ['./table-control.component.css']
})
export class TableControlComponent implements OnInit {
  deleteList: IdBase[] = [];
  selectionList: any[] = [];

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
  }

  add(): void {
    this.eventBus.showHideRow(true);
    console.log(this.selectionList);
    if (this.router.url == '/Students') {
      
    }
  }

  save(): void {
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

    console.log('deleteList: ', this.deleteList);

    crud.delete().subscribe(
      (result: any) => {
        console.log(result);
        window.location.reload();
      },
      (error: any) => {
        console.log(error);
      }
    )
  }
}
