// modules
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { YearprogramRoutingModule } from './yearprogram-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { MatCardModule, MatSortModule, MatFormFieldModule, MatInputModule, MatDatepickerModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatMomentDateModule, MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { CoreModule } from '../core.module';

// components
import { YearprogramComponent } from './yearprogram.component';
import { StudentsComponent } from './students/students.component';
import { StudentDialogComponent } from './students/student-dialog.component';
import { MentorDialogComponent } from './mentors/mentor-dialog.component';
import { MentorComponent } from './mentors/mentor.component';
import { GroupComponent } from './groups/group.component';
import { GroupDialogComponent } from './groups/group-dialog.component';
import { GroupMembersListComponent } from './group-members-list/group-members-list.component';
import { AddGroupMentorDialogComponent } from './group-members-list/add-group-mentor-dialog.component';
import { AddGroupStudentDialogComponent } from './group-members-list/add-group-student-dialog.component';

//services
import { StudentService } from '../services/student.service';
import { MentorService } from '../services/mentor.service';
import { AcademyProgramStateService } from '../academymgmt/academy-program/academy-program-state.service';
import { GroupService } from '../services/group.service';
import { GroupMemberService } from '../services/group-member.service';
import { AcademyService } from '../services/academy.service';
import { AcademyProgramService } from '../services/academy-program.service';

// pipes
import { AgePipe } from '../shared/pipes/age.pipe';

@NgModule({
  declarations: [
    YearprogramComponent,
    StudentsComponent,
    StudentDialogComponent,
    MentorDialogComponent,
    MentorComponent,
    GroupComponent,
    GroupDialogComponent,
    GroupMembersListComponent,
    AddGroupMentorDialogComponent,
    AddGroupStudentDialogComponent,
    AgePipe
  ],
  entryComponents: [
    StudentDialogComponent,
    MentorDialogComponent,
    GroupDialogComponent,
    AddGroupMentorDialogComponent,
    AddGroupStudentDialogComponent,
    GroupMembersListComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    YearprogramRoutingModule,
    FormsModule,
    SharedModule,
    ReactiveFormsModule,
    MatCardModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    FlexLayoutModule,
    MatDatepickerModule,
    MatMomentDateModule
  ],
  exports: [
    MatSortModule,
    MatFormFieldModule,
    MatInputModule 
  ],
  providers: [
    StudentService,
    MentorService,
    AcademyProgramStateService,
    GroupService,
    GroupMemberService,
    AcademyService,
    AcademyProgramService,
    {provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: {useUtc: true}}
  ]
})
export class YearprogramModule { }
