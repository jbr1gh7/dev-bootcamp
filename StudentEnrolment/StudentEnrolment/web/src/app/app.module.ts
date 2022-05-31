import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { StudentTableComponent } from './components/student-table/student-table.component';
import { TableControlComponent } from './components/table-control/table-control.component';
import { CourseTableComponent } from './components/course-table/course-table.component';
import { SubjectTableComponent } from './components/subject-table/subject-table.component';
import { DeleteCellComponent } from './components/delete-cell/delete-cell.component';
import { AddRowComponent } from './components/add-row/add-row.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    StudentTableComponent,
    TableControlComponent,
    CourseTableComponent,
    SubjectTableComponent,
    DeleteCellComponent,
    AddRowComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgMultiSelectDropDownModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
