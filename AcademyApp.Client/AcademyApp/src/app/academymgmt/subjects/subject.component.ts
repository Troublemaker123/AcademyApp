import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatDialog, MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { Subscription } from 'rxjs/Subscription';

import { SubjectService } from '../../services/subject.service';
import { Subjects } from '../../shared/models/subjects';
import { SubjectDialogComponent } from './subject-dialog.component';
import { AcademyProgramStateService } from '../academy-program/academy-program-state.service';
import { WarnDialogComponent } from '../../shared/warn-dialog/warn-dialog';
import { Academy } from 'src/app/shared/models/academy';
import { AcademyService } from '../../services/academy.service';
import { AcademyProgramService } from '../../services/academy-program.service';
import { ThrowStmt } from '@angular/compiler';
import { Subject } from 'rxjs';


@Component({
  selector: 'app-subject',
  templateUrl: 'subject.component.html'
})
export class SubjectsComponent implements OnInit, AfterViewInit {
 

  public subject: MatTableDataSource<any>;
  public subjects= new MatTableDataSource<Subjects>();// Subjects[] = [];
  columnsToDisplay = ['name', 'description', 'Actions'];

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  academies: Academy[] = [];
  selectedAcademyId:number;

  constructor(   
    private subjectService: SubjectService,
    public dialog: MatDialog,
    private academyService:AcademyService,
    private acadepyProgramService:AcademyProgramService
    )  { };
  

  public ngOnInit() {

    this.getAcademies();
    this.subjects.paginator = this.paginator;
  }

  ngAfterViewInit(): void {
    this.subjects.sort = this.sort;
  }

  private getAcademies()
  {
    this.academyService.getAllAcademies().subscribe(result => {
      this.academies = result;
      this.selectedAcademyId = this.academies[0].id;

      let aid = this.selectedAcademyId;
      this.getAllSubjects(aid);
    });
  }

  public openDialog(subject: Subjects): void {
    const dialogRef = this.dialog.open(SubjectDialogComponent, {
      width: '500px',
      disableClose: true,
      data: { subject : subject, academy: this.selectedAcademyId }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'ok') {
        this.getAllSubjects(this.selectedAcademyId);
      }
    });
  }

  public openWarningDialog(subject: Subjects): void {
    const dialogRef = this.dialog.open(WarnDialogComponent, {
      // new Warning Dialog
      width: '300px',
      disableClose: true,
      data: { subject }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'ok') {
        this.deleteSubject(subject);
      }
    });
  }

  private deleteSubject(subject: Subjects) {
    this.subjectService.delete(subject.id)
      .subscribe(result => {
        this.getAllSubjects(this.selectedAcademyId);
      });
  }

  private getAllSubjects(aid: number) {
    this.subjectService.GetAllSubjects(aid)
      .subscribe(result => {
        this.subjects.data = result as Subjects[];
      });
  }

  public onChangeAcademy(aid: number)
  {
    this.selectedAcademyId = aid;
    this.getAllSubjects(aid);
  }

}
