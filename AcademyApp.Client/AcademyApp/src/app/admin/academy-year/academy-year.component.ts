import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatDialog } from '@angular/material';
import { AdminService } from '../admin.service';
import { AcademyProgram } from '../../shared/models/academyProgram';
import { FormGroup, FormControl, NgForm } from '@angular/forms';
import { AcademyYearDialogComponent } from './academy-year-dialog.component';

@Component({
  selector: 'academy-year',
  templateUrl: 'academy-year.component.html'
})
export class AcademyYearComponent implements OnInit {
  public programs: AcademyProgram[] = [];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(
    private adminService: AdminService,
    public dialog: MatDialog
  ) { }


  public ngOnInit() {
    this.getAllPrograms();
  }

  public openDialog(program: AcademyProgram): void {
    const dialogRef = this.dialog.open(AcademyYearDialogComponent, {
      width: '600px',
      data: { program: program }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'ok') {
        this.getAllPrograms();
      }
    });
  }

  public openWarningDialog(program: AcademyProgram): void {
    const dialogRef = this.dialog.open(AcademyYearDialogComponent, { // new Warning Dialog
      width: '300px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'ok') {
        this.deleteProgram(program.id);
      }
    });
  }

  private deleteProgram(programId: number) {
    this.adminService.delete(programId)
      .subscribe(result => {
        this.getAllPrograms();
      });
  }

  private getAllPrograms() {
    this.adminService.GetAllAcademyPrograms()
      .subscribe(result => {
        this.programs = result;
      });
  }

};
