import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';

// modules
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminRoutingModule } from './admin-routing.module';
import { SharedModule } from '../shared/shared.module';


// services
import { AcademyProgramService } from '../services/academy-program.service';
import { AcademyProgramStateService } from '../academymgmt/academy-program/academy-program-state.service';
import { StudentService } from '../services/student.service';
import { MentorService } from '../services/mentor.service';
import { SubjectService } from '../services/subject.service';
import { GroupService } from '../services/group.service';
import { GroupMemberService } from '../services/group-member.service';
import { AcademyService } from '../services/academy.service';
import { RoleService } from '../services/role.service';

// components
import { AdminComponent } from './admin.component';
import { RoleListComponent } from './roles/role-list.component';
import { RoleDialogComponent } from './roles/role-dialog.component';
import { UserListComponent } from './users/user-list.component';
import { UserDialogComponent } from './users/user-dialog.component';
import { CategoryComponent } from './category/category.component';
import { CategoryDialogComponent } from './category/category-dialog.component';
import { SubCategoryDialogComponent } from './category/sub-category-dialog.component';
import { ClassroomComponent } from './classrooms/classroom.component';
import { ClassroomDialogComponent } from './classrooms/classroom-dialog.component';
import { CoreModule } from '../core.module';



@NgModule({
  declarations: [
    AdminComponent,
    RoleListComponent,
    RoleDialogComponent,
    UserListComponent,
    UserDialogComponent,
    CategoryComponent,
    CategoryDialogComponent,
    SubCategoryDialogComponent,
    ClassroomComponent,
    ClassroomDialogComponent
  ],
  entryComponents: [
    RoleDialogComponent,
    UserDialogComponent,
    CategoryDialogComponent,
    SubCategoryDialogComponent,
    ClassroomDialogComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    AdminRoutingModule,
    FormsModule,
    SharedModule,
    ReactiveFormsModule,
    FlexLayoutModule
  ],
  exports: [

  ],
  providers: [
    AcademyProgramService,
    StudentService,
    MentorService,
    SubjectService,
    AcademyProgramStateService,
    GroupService,
    GroupMemberService,
    AcademyService,
    RoleService
  ],

})
export class AdminModule { }
