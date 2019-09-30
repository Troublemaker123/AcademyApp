import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

// modules
import { FormsModule, ReactiveFormsModule, FormGroup } from '@angular/forms';
import { AdminRoutingModule } from './admin-routing.module';
import { SharedModule } from '../shared/shared.module';
import { MatSortModule, MatTableModule } from '@angular/material';

// services
import { AdminService } from './admin.service';
import { StudentService } from './student.service';
import { MentorService } from './mentor.service';
import { SubjectService } from './subject.service';
import { AcademyProgramService } from './academy-year/academy-program.service';

// components
import { AdminComponent } from './admin.component';
import { AcademyYearComponent } from './academy-year/academy-year.component';
import { AcademyYearDialogComponent } from './academy-year/academy-year-dialog.component';
import { StudentsComponent } from './students/students.component';
import { StudentDialogComponent } from './students/student-dialog.component';
import { MentorDialogComponent } from './mentors/mentor-dialog.component';
import { MentorComponent } from './mentors/mentor.component';
import { SubjectDialogComponent } from '../subjects/subject-dialog.component';
import { SubjectsComponent } from '../subjects/subject.component';

import { WarnDialogComponent } from '../shared/warn-dialog/warn-dialog';



@NgModule({
  declarations: [
    AdminComponent,
    AcademyYearComponent,
    StudentsComponent,
    AcademyYearDialogComponent,
    StudentDialogComponent,
    MentorDialogComponent,
    MentorComponent,
    SubjectDialogComponent,
    SubjectsComponent,
    WarnDialogComponent,
  ],
  entryComponents: [
    AcademyYearDialogComponent,
    StudentDialogComponent,
    MentorDialogComponent,
    SubjectDialogComponent,
    WarnDialogComponent,

  ],
  imports: [
    CommonModule,
    HttpClientModule,
    AdminRoutingModule,
    FormsModule,
    SharedModule,
    MatSortModule,
    MatTableModule,

  ],
  providers: [
    AdminService,
    StudentService,
    MentorService,
    SubjectService,
    AcademyProgramService,
 
  ],

})
export class AdminModule { }