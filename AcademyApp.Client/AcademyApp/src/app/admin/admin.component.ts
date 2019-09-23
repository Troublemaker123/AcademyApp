import { Component, OnInit } from '@angular/core';
import { AcademyProgramService } from './academy-year/academy-program.service';
import { AcademyProgram } from '../shared/models/academyProgram';
import { AdminService } from './admin.service';



@Component({
  selector: 'admin',
  templateUrl: 'admin.component.html'
})
export class AdminComponent implements OnInit {

  public programs: AcademyProgram[] = [];

  constructor(private academyProgramService: AcademyProgramService,
    private adminService: AdminService,) {
  }


  public ngOnInit() {
    this.getAllAcademyPrograms();
  }

  public getAllAcademyPrograms() {
    this.adminService.GetAllAcademyPrograms()
    .subscribe(result => {
      this.programs = result;
    });

  }

  public onChangeAcademyProgram(academyProgram: AcademyProgram) {
    this.academyProgramService.setAcademyProgram(academyProgram);
  }
}

