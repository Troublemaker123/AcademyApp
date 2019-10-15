import { Component, OnInit } from '@angular/core';
import { AcademyProgramStateService } from './academy-program/academy-program-state.service';
import { AcademyProgram } from '../shared/models/academyProgram';
import { AcademyProgramService } from './academy-program.service';


@Component({
  selector: 'app-admin',
  templateUrl: 'admin.component.html'
})
export class AdminComponent implements OnInit {

  public programs: AcademyProgram[] = [];

  constructor(private academyProgramStateService: AcademyProgramStateService,
              private academyProgramService: AcademyProgramService, ) {
  }

  public ngOnInit() {
    this.getAllAcademyPrograms();
  }


  public getAllAcademyPrograms() {
    this.academyProgramService.GetAllAcademyPrograms()
      .subscribe(result => {
        this.programs = result;
        const academyPrograms = this.programs.filter((program: AcademyProgram) => program.isCurrent === true);
        if (academyPrograms.length > 0) {
          const academyProgram = academyPrograms[0];
          this.academyProgramStateService.setAcademyProgramId(academyProgram.id);
          this.academyProgramStateService.setAcademyProgramIdEvent(academyProgram.id);
        }
      });
  }

  public onChangeAcademyProgram(event: any) {
    if (event.target.value) {
      this.academyProgramStateService.setAcademyProgramId(event.target.value);
      this.academyProgramStateService.setAcademyProgramIdEvent(event.target.value);
    }
  }
}

