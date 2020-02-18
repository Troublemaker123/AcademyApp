// modules
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeRouterModule } from './employee-router.module';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatMomentDateModule, MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';

// components
import { AcademyProgramComponent } from './academy-program/academy-program.component';
import { AcademyYearDialogComponent } from './academy-program/academy-program-dialog.component';
import { SubjectDialogComponent } from './subjects/subject-dialog.component';
import { SubjectsComponent } from './subjects/subject.component';
import { AcademyDialogComponent } from './academy/academy-dialog/academy-dialog.component';
import { AcadmylistComponent } from './academy/acadmylist.component';
import { EmployeeComponent } from './employee.component';
import { AcademyProgramEventsDialogComponent } from './academy-program/academy-program-events-dialog.component';

// services
import { AcademyProgramService } from '../services/academy-program.service';
import { StudentService } from '../services/student.service';
import { MentorService } from '../services/mentor.service';
import { SubjectService } from '../services/subject.service';
import { AcademyProgramStateService } from './academy-program/academy-program-state.service';
import { GroupService } from '../services/group.service';
import { GroupMemberService } from '../services/group-member.service';
import { AcademyService } from '../services/academy.service';
import { CoreModule } from '../core.module';


@NgModule({
  declarations: [
    EmployeeComponent,
    AcademyProgramComponent,
    AcademyYearDialogComponent,
    SubjectDialogComponent,
    SubjectsComponent,
    AcademyDialogComponent,
    AcadmylistComponent,
    AcademyProgramEventsDialogComponent
  ],
  entryComponents: [
    AcademyYearDialogComponent,
    SubjectDialogComponent,
    AcademyDialogComponent,
    AcademyProgramEventsDialogComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    EmployeeRouterModule,
    FormsModule,
    SharedModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    MatMomentDateModule
  ],
  exports: [],
  providers: [
    AcademyProgramService,
    StudentService,
    MentorService,
    SubjectService,
    AcademyProgramStateService,
    GroupService,
    GroupMemberService,
    AcademyService,
    {provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: {useUtc: true}}
  ]
})
export class EmployeeModule { }
