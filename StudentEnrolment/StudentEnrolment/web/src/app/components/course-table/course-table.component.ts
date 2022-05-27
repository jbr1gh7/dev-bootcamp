import { Component, OnInit } from '@angular/core';
import { Course } from 'src/app/models/course.model';
import { CourseCrudService } from 'src/app/services/course-crud.service';

@Component({
  selector: 'app-course-table',
  templateUrl: './course-table.component.html',
  styleUrls: ['./course-table.component.css']
})
export class CourseTableComponent implements OnInit {
  rows: Course[] = [];

  constructor(private courseCrud: CourseCrudService) {}

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
