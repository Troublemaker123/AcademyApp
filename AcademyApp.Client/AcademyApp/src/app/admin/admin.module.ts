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
import { AcademyYearWarnDialogComponent } from './academy-year/academy-year-warn-dialog-component';
import { StudentDialogComponent } from './students/student-dialog.component';
import { StudentWarnDialogComponent } from './students/student-warn-dialog';
import { MentorDialogComponent } from './mentors/mentor-dialog.component';
import { MentorComponent } from './mentors/mentor.component';
import { SubjectDialogComponent } from '../subjects/subject-dialog.component';
import { SubjectWarnDialogComponent } from '../subjects/subject-warn-dialog.component';
import { SubjectsComponent } from '../subjects/subject.component';
import { MentorWarnDialogComponent } from './mentors/mentor-warn-dialog';



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
    SubjectDialogComponent,
    SubjectWarnDialogComponent,
    SubjectsComponent
  ],
  entryComponents: [
    AcademyYearDialogComponent,
    AcademyYearWarnDialogComponent,
    StudentDialogComponent,
    StudentWarnDialogComponent,
    MentorDialogComponent,
    MentorWarnDialogComponent,
    SubjectDialogComponent,
    SubjectWarnDialogComponent,

  ],
  imports: [
    CommonModule,
    HttpClientModule,
    AdminRoutingModule,
    ReactiveFormsModule,
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