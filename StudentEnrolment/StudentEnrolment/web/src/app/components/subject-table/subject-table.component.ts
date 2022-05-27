import { Component, OnInit } from '@angular/core';
import { Subject } from 'src/app/models/subject.model';
import { SubjectCrudService } from 'src/app/services/subject-crud.service';

@Component({
  selector: 'app-subject-table',
  templateUrl: './subject-table.component.html',
  styleUrls: ['./subject-table.component.css']
})
export class SubjectTableComponent implements OnInit {
  rows: Subject[] = [];
  selectState: string[] = [];

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

  select(id: string, event: any): void {
    if (event.target.checked === true) 
      this.selectState.push(id);
    
    if (event.target.checked === false) 
      this.selectState = this.selectState.filter((item) => item !== id);

    for(let i=0; i<this.selectState.length; i++) 
      console.log('id: ', this.selectState[i]);
  }
}
