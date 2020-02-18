import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { MatDialog, MatTableDataSource, MatSort, MatPaginator } from '@angular/material';
import { AcademyProgramService } from '../../services/academy-program.service';
import { AcademyProgram } from '../../shared/models/academyProgram';
import { AcademyYearDialogComponent } from './academy-program-dialog.component';
import { WarnDialogComponent } from 'src/app/shared/warn-dialog/warn-dialog';
import { Academy } from 'src/app/shared/models/academy';
import { AcademyService } from '../../services/academy.service';
import { AcademyProgramEventsDialogComponent } from './academy-program-events-dialog.component';


@Component({
  selector: 'app-academy-year',
  templateUrl: 'academy-program.component.html'
})
export class AcademyProgramComponent implements OnInit, AfterViewInit {
  
  public programs = new MatTableDataSource<AcademyProgram>();// AcademyProgram[] = [];
  academies: Academy[];

  columnsToDisplay = ['academyName', 'startDate', 'endDate', 'isCurrent', 'Actions', 'Events'];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor(
    private academyProgramService: AcademyProgramService,
    public dialog: MatDialog,
    private academyService: AcademyService
  ) { }


  public ngOnInit() {
    this.getAllPrograms();
    this.getAllAcademies();
    this.programs.paginator = this.paginator;
  }

  ngAfterViewInit(): void {
    this.programs.sort = this.sort;
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

  public openEventsDialog(program: AcademyProgram):void{
    const dialogRef = this.dialog.open(AcademyProgramEventsDialogComponent, {
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
        this.programs.data = result as AcademyProgram[];
      });
  }

  private getAllAcademies() {
    this.academyService.getAllAcademies()
      .subscribe(result => {
        this.academies = result;
      });
  }

  toggle(isCurrent: boolean) {
    isCurrent = !isCurrent;
  }

}
