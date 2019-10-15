import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { Subjects } from '../../shared/models/subjects';
import { SubjectService } from '../subject.service';
import { AcademyProgramStateService } from '../academy-program/academy-program-state.service';
import { Subscriber } from 'rxjs';


@Component({
  templateUrl: 'subject-dialog.component.html'
})
export class SubjectDialogComponent implements OnInit {

  public subject: Subjects = new Subjects();

  public title: string;

  public academyProgramObservable = Subscriber;

  private isEditMode = false;

  constructor(
    private subjectService: SubjectService,
    private academyProgramStateService: AcademyProgramStateService,
    private dialogRef: MatDialogRef<SubjectDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }


  public ngOnInit() {
    if (this.data.subject) {
      // edit
      this.isEditMode = true;
      this.title = 'Edit subject';
      this.subject = this.data.subject;
    } else {
      // create
      this.title = 'Add new subject';
    }
  }

  public onSubmit() {
    if (this.isEditMode) {
      this.subjectService.update(this.subject).subscribe(result => {
        this.dialogRef.close('ok');
      });
    } else {
      this.subject.academyProgramId = this.academyProgramStateService.getAcademyProgramId();
      this.subjectService.create(this.subject).subscribe(result => {
        this.dialogRef.close('ok');
      });
    }
  }

  public onCancel(form: NgForm) {
    this.dialogRef.close('cancel');
  }
}


