import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { YearprogramComponent } from './yearprogram.component';
import { GroupComponent } from './groups/group.component';
import { StudentsComponent } from './students/students.component';
import { MentorComponent } from './mentors/mentor.component';

const routes: Routes = [
  {

    path: '', component: YearprogramComponent,
    children: [
      { path: '', redirectTo: 'groups', pathMatch: 'full' },
      {
        path: 'groups', component: GroupComponent
      },
      {
        path: 'students', component: StudentsComponent
      },
      {
        path: 'mentors', component: MentorComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class YearprogramRoutingModule { }
