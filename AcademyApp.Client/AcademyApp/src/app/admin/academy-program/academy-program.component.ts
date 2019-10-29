import { Component, OnInit } from '@angular/core';
import { MatDialog, MatTableDataSource } from '@angular/material';
import { AcademyProgramService } from '../academy-program.service';
import { AcademyProgram } from '../../shared/models/academyProgram';
import { AcademyYearDialogComponent } from './academy-program-dialog.component';
import { WarnDialogComponent } from 'src/app/shared/warn-dialog/warn-dialog';


@Component({
  selector: 'app-academy-year',
  templateUrl: 'academy-program.component.html'
})
export class AcademyProgramComponent implements OnInit {
  public programs: AcademyProgram[] = [];
  columnsToDisplay = ['startDate', 'endDate', 'isCurrent', 'Actions'];
   dataSource: MatTableDataSource<AcademyProgram>;
  constructor(
    private academyProgramService: AcademyProgramService,
    public dialog: MatDialog
  ) { }


  public ngOnInit() {
    this.getAllPrograms();
  }


  public openDialog(program: AcademyProgram): void {
    const dialogRef = this.dialog.open(AcademyYearDialogComponent, {
      width: '500px',
      disableClose: true,
      data: { program }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'ok') {
        this.getAllPrograms();
      }
    });
  }

  public openWarningDialog(program: AcademyProgram): void {
    const dialogRef = this.dialog.open(WarnDialogComponent, {
      // new Warning Dialog
      width: '300px',
      disableClose: true,
      data: { program }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'ok') {
        this.deleteProgram(program.id);
      }
    });
  }

  private deleteProgram(programId: number) {
    this.academyProgramService.delete(programId)
      .subscribe(result => {
        this.getAllPrograms();
      });
  }

  private getAllPrograms() {
    this.academyProgramService.GetAllAcademyPrograms()
      .subscribe(result => {
        this.programs = result;
      });
  }

  toggle(isCurrent: boolean) {
    isCurrent = !isCurrent;
  }

}
