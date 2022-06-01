import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { Course } from 'src/app/models/course.model';
import { CourseCrudService } from 'src/app/services/course-crud.service';
import { StudentCrudService } from 'src/app/services/student-crud.service';
import { SubjectCrudService } from 'src/app/services/subject-crud.service';

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

  constructor(
    private studentCrud: StudentCrudService,
    private courseCrud: CourseCrudService,
    private subjectCrud: SubjectCrudService,
    private router: Router
  ) { }

  ngOnInit(): void {
    //pass list of entities to this component
    //pass list into populateCheckboxes()
    //for course table, there will need to be 2 multiselect

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

  populateCheckboxes(rowList: any[], isTypeStudent: boolean): void {
    this.courseList = rowList;
    let dropdownFromDb = [];

    for (let i = 0; i < rowList.length; i++) {
      let text;

      if (isTypeStudent)
        text = rowList[i].firstName;
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
