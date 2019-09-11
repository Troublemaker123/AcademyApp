import { Component, Inject, OnInit } from '@angular/core';
import { NgForm, FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { Student } from 'src/app/shared/models/student';
import { StudentService } from '../student.service';

@Component({
  templateUrl: 'student-warn-dialog.html'
})
export class StudentWarnDialogComponent implements OnInit {

  public student: Student = new Student();

  constructor(
    private studentService: StudentService,
    private dialogRef: MatDialogRef<StudentWarnDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  public ngOnInit() {
    this.student = this.data.student;
  }

  public onDelete() {
    debugger;
    this.studentService.delete(this.student.id).subscribe(result => {
      this.dialogRef.close('ok');
    });
  }
  public onCancel(form: NgForm) {
    this.dialogRef.close('cancel');
  }
}
