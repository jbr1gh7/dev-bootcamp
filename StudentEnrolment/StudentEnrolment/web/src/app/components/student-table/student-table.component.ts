import { Component, OnInit } from '@angular/core';
import { IdBase } from 'src/app/models/id-base.model';
import { Student } from 'src/app/models/student.model';
import { EventBusService } from 'src/app/services/event-bus.service';
import { StudentCrudService } from 'src/app/services/student-crud.service';

@Component({
  selector: 'app-student-table',
  templateUrl: './student-table.component.html',
  styleUrls: ['./student-table.component.css']
})
export class StudentTableComponent implements OnInit {
  rows: Student[] = [];
  selectState: IdBase[] = [];
  isAdding: boolean = false;
  
  constructor(
    private studentCrud: StudentCrudService,
    private eventBus: EventBusService
  ) 
  { 
    this.eventBus.isAddingEvent.subscribe((adding: boolean) => this.isAdding = adding); 
  }

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
