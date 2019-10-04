import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AcademyYearComponent } from './academy-year/academy-year.component';
import { AdminComponent } from './admin.component';
import { StudentsComponent } from './students/students.component';
import { MentorComponent } from './mentors/mentor.component';
import { SubjectsComponent } from '../subjects/subject.component';
import { GroupComponent } from './groups/group.component';

const routes: Routes = [
  {

    path: '', component: AdminComponent,
    children: [
      {
        path: 'academy-year', component: AcademyYearComponent
      },
      {
        path: 'students', component: StudentsComponent
      },
      {
        path: 'mentors', component: MentorComponent
      },
      {
        path: 'subjects', component: SubjectsComponent
      },
      {
        path: 'groups', component: GroupComponent
      }
    ]
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
