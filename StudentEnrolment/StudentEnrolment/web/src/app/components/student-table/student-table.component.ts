import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/models/student.model';
import { StudentCrudService } from 'src/app/services/student-crud.service';

@Component({
  selector: 'app-student-table',
  templateUrl: './student-table.component.html',
  styleUrls: ['./student-table.component.css']
})
export class StudentTableComponent implements OnInit {
  rows: Student[] = [];
  
  constructor(private studentCrud: StudentCrudService) { }

  ngOnInit(): void {
    this.studentCrud.list()
    .subscribe(
      (result: Student[]) => {
        this.rows = result;
      },
      (error: any) => {
        console.log(error);
      }
    )
  }

}
