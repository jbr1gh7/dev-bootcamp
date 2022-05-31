import { Component, OnInit } from '@angular/core';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { Course } from 'src/app/models/course.model';
import { CourseCrudService } from 'src/app/services/course-crud.service';

@Component({
  selector: '[app-add-row]',
  templateUrl: './add-row.component.html',
  styleUrls: ['./add-row.component.css']
})
export class AddRowComponent implements OnInit {
  dropdownList: any = [];
  selectedItems: any = [];
  dropdownSettings: IDropdownSettings = {};

  constructor(
    private courseCrud: CourseCrudService
  ) 
  { 

  }

  ngOnInit(): void {
    this.courseCrud.list().subscribe(
      (result: any) => {
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

        console.log(this.dropdownList)
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

  onItemSelect(item: any) {
    console.log(item);
  }

  onSelectAll(items: any) {
    console.log(items);
  }
}
