import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

// modules
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminRoutingModule } from './admin-routing.module';
import { SharedModule } from '../shared/shared.module';

// services
import { AdminService } from './admin.service';
import { StudentService } from './student.service';

// components
import { AdminComponent } from './admin.component';
import { AcademyYearComponent } from './academy-year/academy-year.component';
import { AcademyYearDialogComponent } from './academy-year/academy-year-dialog.component';
import { StudentsComponent } from './students/students.component';
import { AcademyYearWarnDialogComponent } from './academy-year/academy-year-warn-dialog-component';
import { StudentDialogComponent } from './students/student-dialog.component';
import { StudentWarnDialogComponent } from './students/student-warn-dialog';
import { MentorService } from './mentor.service';
import { MentorDialogComponent } from './mentors/mentor-dialog.component';
import { MentorWarnDialogComponent } from './mentors/mentor-warn-dialog';
import { MentorComponent } from './mentors/mentor.component';


@NgModule({
  declarations: [
    AdminComponent,
    AcademyYearComponent,
    StudentsComponent,
    AcademyYearDialogComponent,
    AcademyYearWarnDialogComponent,
    StudentDialogComponent,
    StudentWarnDialogComponent,
    MentorDialogComponent,
    MentorWarnDialogComponent,
    MentorComponent,
  ],
  entryComponents:[
    AcademyYearDialogComponent,
    AcademyYearWarnDialogComponent,
    StudentDialogComponent,
    StudentWarnDialogComponent,
    MentorDialogComponent,
    MentorWarnDialogComponent,

  ],
  imports: [
    CommonModule,
    HttpClientModule,
    AdminRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    SharedModule
  ],
  providers: [AdminService,StudentService,MentorService],

})
export class AdminModule { }