import { Component, OnInit } from '@angular/core';
import { Subject } from 'src/app/models/subject.model';
import { IdBase } from 'src/app/models/id-base.model';
import { SubjectCrudService } from 'src/app/services/subject-crud.service';

@Component({
  selector: 'app-subject-table',
  templateUrl: './subject-table.component.html',
  styleUrls: ['./subject-table.component.css']
})
export class SubjectTableComponent implements OnInit {
  rows: Subject[] = [];
  selectState: IdBase[] = [];

  constructor(private subjectCrud: SubjectCrudService) { }

  ngOnInit(): void {
    this.subjectCrud.list()
    .subscribe(
      (result: Subject[]) => {
        this.rows = result;
      },
      (error: any) => {
        console.log(error);
      }
    )
  }
}
