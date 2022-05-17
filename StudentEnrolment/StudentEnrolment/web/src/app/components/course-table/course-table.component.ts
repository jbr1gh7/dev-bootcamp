import { Component, OnInit } from '@angular/core';
import { CourseCrudService } from 'src/app/services/course-crud.service';

@Component({
  selector: 'app-course-table',
  templateUrl: './course-table.component.html',
  styleUrls: ['./course-table.component.css']
})
export class CourseTableComponent implements OnInit {

  constructor(private courseCrud: CourseCrudService) { }

  ngOnInit(): void {
    this.courseCrud.list()
  }

}
