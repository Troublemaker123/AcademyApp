import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { LoginLayoutComponent } from './login/login-layout.component';
import { MenuComponent } from './main.component';
import { AuthGuard } from './shared/helpers/auth.guard';
import { RoleAccessGuard } from './shared/helpers/role-access.guard';
import { Role } from './shared/models/roles';
import { ResetPasswordComponent } from './login/reset-password.component';
import { ForgetPasswordComponent } from './login/forget-password.component';
import { ConfirmEmailComponent } from './login/confirm-email.component';
import { Page404Component } from './page404/page404.component';
import { ChangePasswordComponent } from './login/change-password.component';
import { LoggedGuard } from './shared/helpers/logged.guard';


const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full', canActivate: [AuthGuard] },
  {
    path: 'login', component: LoginLayoutComponent,
    children: [
      { path: '', component: LoginComponent }
    ]
  },
  {
    path: 'main', component: MenuComponent, canActivate: [AuthGuard],
    children: [
      { path: '', redirectTo: 'administration', pathMatch: 'full' },
      {
        path: 'administration',
        loadChildren: () => import(`./admin/admin.module`).then(m => m.AdminModule),
        data: { roles: [Role.Administrator] },
        canActivate: [RoleAccessGuard]
      },
      {
        path: 'academymgmt',
        loadChildren: () => import(`./academymgmt/employee.module`).then(m => m.EmployeeModule),
        data: { roles: [Role["Academy Employee"]] },
        canActivate: [RoleAccessGuard]
      },
      {
        path: 'academyprogrammgmt',
        loadChildren: () => import(`./yearprogram/yearprogram.module`).then(m => m.YearprogramModule),
        data: { roles: [Role["Academy Employee"]] },
        canActivate: [RoleAccessGuard]
      },
      {
        path: 'mentor',
        component: DashboardComponent,
        data: { roles: [Role.Mentor] },
        canActivate: [RoleAccessGuard]
      },
      {
        path: 'student',
        component: DashboardComponent,
        data: { roles: [Role.Student] },
        canActivate: [RoleAccessGuard]
      }
    ]
  },
  { path: 'reset', component: ResetPasswordComponent },
  { path: 'forget/:token', component: ForgetPasswordComponent },
  { path: 'confirm/:token', component: ConfirmEmailComponent},
  { path: 'changepassword', component: ChangePasswordComponent, canActivate: [LoggedGuard]},
  { path: 'error', component: Page404Component },
  { path: '**', component: Page404Component  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
