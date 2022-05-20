import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseTableComponent } from './components/course-table/course-table.component';
import { StudentTableComponent } from './components/student-table/student-table.component';
import { SubjectTableComponent } from './components/subject-table/subject-table.component';

const routes: Routes = [
  {
    path: 'Students', 
    component: StudentTableComponent
  },
  {
    path: 'Courses', 
    component: CourseTableComponent
  },
  {
    path: 'Subjects', 
    component: SubjectTableComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
