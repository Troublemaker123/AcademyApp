import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { MatPaginator, MatDialog, MatTableDataSource } from '@angular/material';
import { Subscription } from 'rxjs/Subscription';

import { SubjectService } from '../subject.service';
import { Subjects } from '../../shared/models/subjects';
import { SubjectDialogComponent } from './subject-dialog.component';
import { AcademyProgramStateService } from '../academy-program/academy-program-state.service';
import { WarnDialogComponent } from '../../shared/warn-dialog/warn-dialog';



@Component({
  selector: 'app-subject',
  templateUrl: 'subject.component.html'
})
export class SubjectsComponent implements OnInit, OnDestroy {

  public academyProgramId: number;
  public subject: MatTableDataSource<any>;
  public subjects: Subjects[] = [];
  columnsToDisplay = ['name', 'description', 'Actions'];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  private subscription: Subscription;

  constructor(
    private academyProgramStateService: AcademyProgramStateService,
    private subjectService: SubjectService,
    public dialog: MatDialog
  ) {
    this.subscription = this.academyProgramStateService.getAcademyProgramIdEvent().subscribe(data => {
      this.academyProgramId = data.academyProgramId;
      this.getAllSubjects(this.academyProgramId);
    });
  }


  public ngOnInit() {
    this.academyProgramId = this.academyProgramStateService.getAcademyProgramId();
    if (this.academyProgramId) {
      this.getAllSubjects(this.academyProgramId);
    }
  }
  public ngOnDestroy() {
    // unsubscribe to ensure no memory leaks
    this.subscription.unsubscribe();
  }

  public openDialog(subject: Subjects): void {
    const dialogRef = this.dialog.open(SubjectDialogComponent, {
      width: '500px',
      disableClose: true,
      data: { subject }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'ok') {
        this.getAllSubjects(this.academyProgramId);
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
    this.subjectService.delete(subject.id, subject.academyProgramId)
      .subscribe(result => {
        this.getAllSubjects(this.academyProgramId);
      });
  }

  private getAllSubjects(academyProgramId: number) {
    this.subjectService.GetAllSubjects(academyProgramId)
      .subscribe(result => {
        this.subjects = result;
      });

  }

}
