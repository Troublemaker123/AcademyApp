import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

// modules
import { FormsModule } from '@angular/forms';
import { AdminRoutingModule } from './admin-routing.module';
import { SharedModule } from '../shared/shared.module';


// services
import { AcademyProgramService } from './academy-program.service';
import { AcademyProgramStateService } from './academy-program/academy-program-state.service';
import { StudentService } from './student.service';
import { MentorService } from './mentor.service';
import { SubjectService } from './subject.service';
import { GroupService } from './group.service';

// components
import { AdminComponent } from './admin.component';
import { AcademyProgramComponent } from './academy-program/academy-program.component';
import { AcademyYearDialogComponent } from './academy-program/academy-program-dialog.component';
import { StudentsComponent } from './students/students.component';
import { StudentDialogComponent } from './students/student-dialog.component';
import { MentorDialogComponent } from './mentors/mentor-dialog.component';
import { MentorComponent } from './mentors/mentor.component';
import { SubjectDialogComponent } from './subjects/subject-dialog.component';
import { SubjectsComponent } from './subjects/subject.component';
import { WarnDialogComponent } from '../shared/warn-dialog/warn-dialog';
import { GroupComponent } from './groups/group.component';
import { GroupDialogComponent } from './groups/group-dialog.component';
import { GroupMemberService } from './group-member.service';
import { GroupMembersComponent } from './group-members/group-members.component';
import { GroupMemberDialogComponent } from './group-members/group-member-dialog.component';


@NgModule({
  declarations: [
    AdminComponent,
    AcademyProgramComponent,
    StudentsComponent,
    AcademyYearDialogComponent,
    StudentDialogComponent,
    MentorDialogComponent,
    MentorComponent,
    SubjectDialogComponent,
    SubjectsComponent,
    WarnDialogComponent,
    GroupComponent,
    GroupDialogComponent,
    GroupMembersComponent,
    GroupMemberDialogComponent,
  ],
  entryComponents: [
    AcademyYearDialogComponent,
    StudentDialogComponent,
    MentorDialogComponent,
    SubjectDialogComponent,
    WarnDialogComponent,
    GroupComponent,
    GroupDialogComponent,
    GroupMemberDialogComponent,
    GroupMembersComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    AdminRoutingModule,
    FormsModule,
    SharedModule,


  ],
  providers: [
    AcademyProgramService,
    StudentService,
    MentorService,
    SubjectService,
    AcademyProgramStateService,
    GroupService,
    GroupMemberService,

  ],

})
export class AdminModule { }
