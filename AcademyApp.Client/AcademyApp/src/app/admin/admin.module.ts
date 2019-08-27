import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

// modules
import { MaterialModule } from '../shared/shared.module';

// services
import { AdminService } from './admin.service';

// components
import { AdminComponent } from './admin.component';
import { GraduateYearComponent } from './graduate-year/graduate-year.component';
import { AdminRoutingModule } from './admin-routing.module';
import { StudentsComponent } from './students/students.component';


@NgModule({
  declarations: [
    AdminComponent,
    GraduateYearComponent,
    StudentsComponent
  ],

  imports: [
    CommonModule,
    HttpClientModule,
    MaterialModule,
    AdminRoutingModule,

  ],
  providers: [AdminService],

})
export class AdminModule { }