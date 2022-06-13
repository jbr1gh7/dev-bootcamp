import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { StudentTableComponent } from './components/student-table/student-table.component';
import { TableControlComponent } from './components/table-control/table-control.component';
import { CourseTableComponent } from './components/course-table/course-table.component';
import { SubjectTableComponent } from './components/subject-table/subject-table.component';
import { DeleteCellComponent } from './components/delete-cell/delete-cell.component';
import { AddSubjectRowComponent } from './components/add-subject-row/add-subject-row.component';
import { AddCourseRowComponent } from './components/add-course-row/add-course-row.component';
import { MultiselectComponent } from './components/multiselect/multiselect.component';
import { AddStudentRowComponent } from './components/add-student-row/add-student-row.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    StudentTableComponent,
    TableControlComponent,
    CourseTableComponent,
    SubjectTableComponent,
    DeleteCellComponent,
    AddSubjectRowComponent,
    AddCourseRowComponent,
    MultiselectComponent,
    AddStudentRowComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgMultiSelectDropDownModule.forRoot(),
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
