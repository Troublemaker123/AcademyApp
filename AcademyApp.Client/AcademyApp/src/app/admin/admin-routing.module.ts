import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { AdminComponent } from './admin.component';
import { RoleListComponent } from './roles/role-list.component';
import { UserListComponent } from './users/user-list.component';
import { CategoryComponent } from './category/category.component';
import { ClassroomComponent } from './classrooms/classroom.component';

const routes: Routes = [
  {

    path: '', component: AdminComponent,
    children: [
      { path: '', redirectTo: 'roles', pathMatch: 'full' },
      {
        path: 'roles', component: RoleListComponent
      },
      {
        path: 'users', component: UserListComponent
      },
      {
        path: 'categories', component: CategoryComponent
      },
      {
        path: 'classrooms', component: ClassroomComponent
      }
    ]
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
