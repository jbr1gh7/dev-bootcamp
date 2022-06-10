import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { Course } from 'src/app/models/course.model';
import { EventBusService } from 'src/app/services/event-bus.service';

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
  type: string = '';

  constructor(
    private eventBus: EventBusService,
    private router: Router
  ) 
  { }

  ngOnInit(): void {
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'item_id',
      textField: 'item_text',
      selectAllText: 'Select All',
      unSelectAllText: 'Deselect All',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };
  }

  populateCheckboxes(rowList: any[], type: string): void {
    this.type = type;
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
          item_id: rowList[i].id,
          item_text: text
        }
      );
    }

    this.dropdownList = dropdownFromDb;
    console.log(this.dropdownList);
  }

  passSelections(): void {
    if (this.router.url == '/Courses') {
      if (this.type == 'student') {
        this.eventBus.passCourseStudentSelectionList(this.selectedItems);
        return;
      }
      else if (this.type == 'subject') {
        this.eventBus.passCourseSubjectSelectionList(this.selectedItems);
        return;
      }
    }

    this.eventBus.passSelectionList(this.selectedItems);
  }

  onItemSelect(): void {
    console.log('selectedItems: ', this.selectedItems);
    this.passSelections();
  }

  onSelectAll(): void {
    console.log('selectedItems: ', this.selectedItems);
    this.passSelections();
  }
}
