import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EmployeeComponent } from './employee.component';
import { AcadmylistComponent } from './academy/acadmylist.component';
import { AcademyProgramComponent } from './academy-program/academy-program.component';
import { SubjectsComponent } from './subjects/subject.component';

const routes: Routes = [
  {

    path: '', component: EmployeeComponent,
    children: [
      { path: '', redirectTo: 'academy', pathMatch: 'full' },
      {
        path: 'academy', component: AcadmylistComponent
      },
      {
        path: 'academy-program', component: AcademyProgramComponent
      },
      {
        path: 'subjects', component: SubjectsComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeRouterModule { }
