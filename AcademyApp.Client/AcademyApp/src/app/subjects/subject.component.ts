import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatDialog, MatTableDataSource } from '@angular/material';
import { FormGroup, FormControl, NgForm } from '@angular/forms';
import { SubjectService } from '../admin/subject.service';
import { Subjects } from '../shared/models/subjects';
import { SubjectDialogComponent } from './subject-dialog.component';
import { SubjectWarnDialogComponent } from './subject-warn-dialog.component';



@Component({
  selector: 'subject',
  templateUrl: 'subject.component.html'
})
export class SubjectsComponent implements OnInit {
  public subjects: Subjects[] = [];
  columnsToDisplay = ['name', 'description', 'Actions'];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(
    private subjectService: SubjectService,
    public dialog: MatDialog
  ) { }


  public ngOnInit() {
    this.getAllSubjects();
  }

  public openDialog(subject: Subjects): void {
    const dialogRef = this.dialog.open(SubjectDialogComponent, {
      width: '500px',
      disableClose: true,
      data: { subject: subject }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'ok') {
        this.getAllSubjects();
      }
    });
  }

  public openWarningDialog(subject: Subjects): void {
    debugger;
    const dialogRef = this.dialog.open(SubjectWarnDialogComponent, {
      // new Warning Dialog
      width: '300px',
      disableClose: true,
      data: { subject: subject }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'ok') {
        this.deleteSubject(subject.id);
      }
    });
  }

  private deleteSubject(subjectId: number) {
    this.subjectService.delete(subjectId)
      .subscribe(result => {
        this.getAllSubjects();
      });
  }

  private getAllSubjects() {
    this.subjectService.GetAllSubjects()
      .subscribe(result => {
        this.subjects = result;
      });

  }

};
