import { Component, OnInit } from '@angular/core';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { Course } from 'src/app/models/course.model';
import { CourseCrudService } from 'src/app/services/course-crud.service';
import { EventBusService } from 'src/app/services/event-bus.service';

@Component({
  selector: '[app-add-row]',
  templateUrl: './add-row.component.html',
  styleUrls: ['./add-row.component.css']
})
export class AddRowComponent implements OnInit {
  dropdownList: any = [];
  selectedItems: any = [];
  dropdownSettings: IDropdownSettings = {};
  courseList: Course[] = [];
  isAdding: boolean = false;

  constructor(
    private courseCrud: CourseCrudService,
    private eventBus: EventBusService
  ) 
  { 
  }

  ngOnInit(): void {

    this.courseCrud.list().subscribe(
      (result: any) => {
        this.courseList = result;
        let dropdownFromDb = [];

        for (let i = 0; i < result.length; i++) {
          dropdownFromDb.push(
            {
              item_id: i + 1,
              item_text: result[i].name
            }
          );
        }

        this.dropdownList = dropdownFromDb;
        console.log(this.dropdownList);
      },
      (error: any) => {
        console.log(error);
      }
    );
    
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'item_id',
      textField: 'item_text',
      selectAllText: 'Select All',
      unSelectAllText: 'Deselect All',
      itemsShowLimit: 0,
      allowSearchFilter: true,
    };
  }

  onItemSelect() {
    console.log(this.selectedItems)
  }

  onSelectAll() {
    console.log(this.selectedItems);
  }

  cancelAdd() {
    this.eventBus.showHideRow(false);
  }
}
