import { Component, OnInit } from '@angular/core';
import { AcademyProgramService } from './academy-year/academy-program.service';
import { AcademyProgram } from '../shared/models/academyProgram';
import { AdminService } from './admin.service';
import { Observable } from 'rxjs';



@Component({
  selector: 'admin',
  templateUrl: 'admin.component.html'
})
export class AdminComponent implements OnInit {

  public programs: AcademyProgram[] = [];

  constructor(private academyProgramService: AcademyProgramService,
    private adminService: AdminService, ) {
  }

  public ngOnInit() {
    this.getAllAcademyPrograms();
  }


  public getAllAcademyPrograms() {
    this.adminService.GetAllAcademyPrograms()
      .subscribe(result => {
        this.programs = result;
        let academyPrograms = this.programs.filter((program: AcademyProgram) => program.isCurrent === true);
        if (academyPrograms.length > 0) {
          let academyProgram = academyPrograms[0];
          this.academyProgramService.setAcademyProgramId(academyProgram.id);
          this.academyProgramService.setAcademyProgramIdEvent(academyProgram.id);
        }
      });
  }

  public onChangeAcademyProgram(event: any) {
    if (event.target.value) {
      this.academyProgramService.setAcademyProgramId(event.target.value);
      this.academyProgramService.setAcademyProgramIdEvent(event.target.value);
    }
  }
}

