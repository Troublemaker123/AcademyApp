import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatSortModule, MatFormFieldModule, MatInputModule, MatCardModule } from '@angular/material';

// modules
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';

// component
import { LoginComponent } from './login.component';
import { LoginLayoutComponent } from './login-layout.component';
import { LoginToolbarComponent } from './login-toolbar.component';

// services
import { LoginService } from './login.service';
import { RouterModule } from '@angular/router';
import { ResetPasswordComponent } from './reset-password.component';
import { ForgetPasswordComponent } from './forget-password.component';
import { ConfirmEmailComponent } from './confirm-email.component';
import { ChangePasswordComponent } from './change-password.component';
import { CoreModule } from '../core.module';


@NgModule({
  declarations: [
    LoginComponent,
    LoginLayoutComponent,
    LoginToolbarComponent,
    ResetPasswordComponent,
    ForgetPasswordComponent,
    ConfirmEmailComponent,
    ChangePasswordComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    MatCardModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    RouterModule
  ],
  exports: [
    MatSortModule,
    MatFormFieldModule,
     MatInputModule,
    MatCardModule
    
  ],
  providers:[
    LoginService
  ]
})
export class LoginModule { }
