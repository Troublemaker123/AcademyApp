import { Component, Inject, OnInit } from '@angular/core';
import { NgForm, FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { Subjects } from '../shared/models/subjects';
import { SubjectService } from '../admin/subject.service';

@Component({
  templateUrl: 'subject-dialog.component.html'
})
export class SubjectDialogComponent implements OnInit {

  public subject: Subjects = new Subjects();
  
  public title: string;

  private isEditMode: boolean = false;

  constructor(
    private subjectService: SubjectService,
    private dialogRef: MatDialogRef<SubjectDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }


  public ngOnInit() {
    if (this.data.subject) {
      // edit
      this.isEditMode = true;
      this.title = 'Edit subject';
      this.subject = this.data.subject;
    }
    else {
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
      this.subjectService.create(this.subject).subscribe(result => {
        this.dialogRef.close('ok');
      });
    }
  }

  public onCancel(form: NgForm) {
    this.dialogRef.close('cancel');
  }
}


