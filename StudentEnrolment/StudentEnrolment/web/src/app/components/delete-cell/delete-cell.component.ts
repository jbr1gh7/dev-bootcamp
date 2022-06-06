import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IdBase } from 'src/app/models/id-base.model';
import { CourseCrudService } from 'src/app/services/course-crud.service';
import { StudentCrudService } from 'src/app/services/student-crud.service';
import { SubjectCrudService } from 'src/app/services/subject-crud.service';

@Component({
  selector: 'app-delete-cell',
  templateUrl: './delete-cell.component.html',
  styleUrls: ['./delete-cell.component.css']
})
export class DeleteCellComponent implements OnInit {
  @Input() row: any = [];
  selectState: IdBase[] = [];

  constructor(
    private studentCrud: StudentCrudService,
    private courseCrud: CourseCrudService,
    private subjectCrud: SubjectCrudService,
    private router: Router
  ) 
  { 

  }

  ngOnInit(): void {
  }

  select(idToDelete: string, event: any): void {
    let idBase = new IdBase(idToDelete);
    let crud;

    if (this.router.url == '/Students') 
      crud = this.studentCrud
    else if (this.router.url == '/Courses') 
      crud = this.courseCrud
    else if (this.router.url == '/Subjects') 
      crud = this.subjectCrud
    else
      return;

    if (event.target.checked === true) {
      crud.pushToDeleteList(idBase);
    }
    
    if (event.target.checked === false) {
      crud.removeFromDeleteList(idBase);
    }    
  }
}
