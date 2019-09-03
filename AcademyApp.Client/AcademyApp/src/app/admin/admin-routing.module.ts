import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AcademyYearComponent } from './academy-year/academy-year.component'
import { AdminComponent } from './admin.component';
import { StudentsComponent } from './students/students.component';

const routes: Routes = [
  {

    path: '', component: AdminComponent, 
    children: [
      {
        path: 'academy-year', component: AcademyYearComponent
      },
      {
        path: 'students', component: StudentsComponent
      }
    ]
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
