import { Component, OnInit } from '@angular/core';
import { AcademyProgram } from '../shared/models/academyProgram';
import { Academy } from '../shared/models/academy';
import { AcademyProgramStateService } from '../academymgmt/academy-program/academy-program-state.service';
import { AcademyProgramService } from '../services/academy-program.service';

@Component({
  selector: 'app-yearprogram',
  templateUrl: './yearprogram.component.html'
})
export class YearprogramComponent implements OnInit {

  public programs: AcademyProgram[] = [];
  selectedProgramId:number;
  currentAcademyName: string;
  currentAcademy: Academy;
  constructor(private academyProgramStateService: AcademyProgramStateService,
              private academyProgramService: AcademyProgramService, ) {
  }

  ngOnInit() {
    this.getAllAcademyPrograms();
  }

  public getAllAcademyPrograms() {
    this.academyProgramService.GetAllAcademyPrograms()
      .subscribe(result => {
        this.programs = result.filter(p => p.isCurrent === true);
        let current = this.programs.find(x => x.isCurrent === true);

        this.selectedProgramId = (current.id);
        this.currentAcademyName = (current.academyName);

        const academyPrograms = this.programs.filter((program: AcademyProgram) => program.isCurrent === true);
        if (academyPrograms.length > 0) {
          const academyProgram = academyPrograms[0];    // if multiple academy year programs are Currently Active, take first for SELECTED
          this.academyProgramStateService.setAcademyProgramId(academyProgram.id);
          this.academyProgramStateService.setAcademyProgramIdEvent(academyProgram.id);
        }
      });
  }

  public onChangeAcademyProgram() {
    if (this.selectedProgramId) {
      this.currentAcademyName = this.programs.find(x => x.id === this.selectedProgramId).academyName;
      this.academyProgramStateService.setAcademyProgramId(this.selectedProgramId);
      this.academyProgramStateService.setAcademyProgramIdEvent(this.selectedProgramId);
      //this.academyProgramStateService.setAcademyName(this.currentAcademyName);
    }
  }


}
