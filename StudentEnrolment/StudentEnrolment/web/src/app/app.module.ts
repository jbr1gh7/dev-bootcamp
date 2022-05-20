import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { StudentTableComponent } from './components/student-table/student-table.component';
import { TableControlComponent } from './components/table-control/table-control.component';
import { CourseTableComponent } from './components/course-table/course-table.component';
import { SubjectTableComponent } from './components/subject-table/subject-table.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    StudentTableComponent,
    TableControlComponent,
    CourseTableComponent,
    SubjectTableComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
