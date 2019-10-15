import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AcademyProgramComponent } from './academy-program/academy-program.component';
import { AdminComponent } from './admin.component';
import { StudentsComponent } from './students/students.component';
import { MentorComponent } from './mentors/mentor.component';
import { GroupComponent } from './groups/group.component';
import { SubjectsComponent } from './subjects/subject.component';

const routes: Routes = [
  {

    path: '', component: AdminComponent,
    children: [
      {
        path: 'academy-program', component: AcademyProgramComponent
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
