import { Component, Inject, OnInit } from '@angular/core';
import { NgForm, FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { Subjects } from '../shared/models/subjects';
import { SubjectService } from '../admin/subject.service';

@Component({
  templateUrl: 'subject-warn-dialog.component.html'
})
export class SubjectWarnDialogComponent implements OnInit {

  public subject: Subjects = new Subjects();

  constructor(
    private subjectService: SubjectService,
    private dialogRef: MatDialogRef<SubjectWarnDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  public ngOnInit() {
    this.subject = this.data.subject;
  }

  public onDelete() {
    debugger;
    this.subjectService.delete(this.subject.id).subscribe(result => {
      this.dialogRef.close('ok');
    });
  }
  public onCancel(form: NgForm) {
    this.dialogRef.close('cancel');
  }
}
