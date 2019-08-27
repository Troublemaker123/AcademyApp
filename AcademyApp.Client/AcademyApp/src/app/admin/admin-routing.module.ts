import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { GraduateYearComponent } from './graduate-year/graduate-year.component'
import { AdminComponent } from './admin.component';
import { StudentsComponent } from './students/students.component';

const routes: Routes = [
  {

    path: '', component: AdminComponent, 
    children: [
      {
        path: 'graduate-year', component: GraduateYearComponent
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
