import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatDialog, MatTableDataSource, MatSort } from '@angular/material';
import { AdminService } from '../admin.service';
import { AcademyProgram } from '../../shared/models/academyProgram';
import { AcademyYearDialogComponent } from './academy-year-dialog.component';
import { WarnDialogComponent } from 'src/app/shared/warn-dialog/warn-dialog';


@Component({
  selector: 'academy-year',
  templateUrl: 'academy-year.component.html'
})
export class AcademyYearComponent implements OnInit{
  public programs: AcademyProgram[] = [];
  columnsToDisplay = ['startDate', 'endDate', 'isCurrent', 'Actions'];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator; 
  @ViewChild(MatSort, {static:true}) sort:MatSort;
   dataSource : MatTableDataSource<AcademyProgram>;
  constructor(
    private adminService: AdminService,
    public dialog: MatDialog
  ) { }


  public ngOnInit() {
    this.getAllPrograms();
  }


  public openDialog(program: AcademyProgram): void {
    const dialogRef = this.dialog.open(AcademyYearDialogComponent, {
      width: '500px',
      disableClose: true,
      data: { program: program }
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
      data: { program: program }
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

  toggle(isCurrent :boolean){
    isCurrent = !isCurrent;
  }

};
