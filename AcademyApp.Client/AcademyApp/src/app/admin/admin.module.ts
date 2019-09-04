import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

// modules
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminRoutingModule } from './admin-routing.module';
import { SharedModule } from '../shared/shared.module';

// services
import { AdminService } from './admin.service';

// components
import { AdminComponent } from './admin.component';
import { AcademyYearComponent } from './academy-year/academy-year.component';
import { AcademyYearDialogComponent } from './academy-year/academy-year-dialog.component';
import { StudentsComponent } from './students/students.component';
import { AcademyYearWarnDialogComponent } from './academy-year/academy-year-warn-dialog-component';

@NgModule({
  declarations: [
    AdminComponent,
    AcademyYearComponent,
    StudentsComponent,
    AcademyYearDialogComponent,
    AcademyYearWarnDialogComponent

  ],
  entryComponents:[
    AcademyYearDialogComponent,
    AcademyYearWarnDialogComponent

  ],
  imports: [
    CommonModule,
    HttpClientModule,
    AdminRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    SharedModule
  ],
  providers: [AdminService],

})
export class AdminModule { }