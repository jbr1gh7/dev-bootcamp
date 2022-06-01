import { Component, OnInit } from '@angular/core';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { Course } from 'src/app/models/course.model';

@Component({
  selector: 'app-multiselect',
  templateUrl: './multiselect.component.html',
  styleUrls: ['./multiselect.component.css']
})
export class MultiselectComponent implements OnInit {
  dropdownList: any = [];
  selectedItems: any = [];
  dropdownSettings: IDropdownSettings = {};
  courseList: Course[] = [];
  placeholder: string = '';

  constructor(
  ) { }

  ngOnInit(): void {
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'item_id',
      textField: 'item_text',
      selectAllText: 'Select All',
      unSelectAllText: 'Deselect All',
      itemsShowLimit: 3,
      allowSearchFilter: true,
    };
  }

  populateCheckboxes(rowList: any[], type: string): void {
    this.courseList = rowList;
    let dropdownFromDb = [];
    this.placeholder = `Select ${type}(s)`


    for (let i = 0; i < rowList.length; i++) {
      let text;

      if (type == 'student')
        text = rowList[i].firstName + ' ' + rowList[i].lastName;
      else
        text = rowList[i].name;

      dropdownFromDb.push(
        {
          item_id: i + 1,
          item_text: text
        }
      );
    }

    this.dropdownList = dropdownFromDb;
    console.log(this.dropdownList);
  }

  onItemSelect() {
    console.log(this.selectedItems)
  }

  onSelectAll() {
    console.log(this.selectedItems);
  }
}
