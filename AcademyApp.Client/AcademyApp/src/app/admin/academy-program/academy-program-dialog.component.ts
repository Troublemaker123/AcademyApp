import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { AcademyProgram } from 'src/app/shared/models/academyProgram';
import { AcademyProgramService } from '../academy-program.service';

@Component({
  templateUrl: 'academy-program-dialog.component.html'
})
export class AcademyYearDialogComponent implements OnInit {

  public program: AcademyProgram = new AcademyProgram();

  public title: string;

  private isEditMode = false;

  constructor(
    private academyProgramService: AcademyProgramService,
    private dialogRef: MatDialogRef<AcademyYearDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }


  public ngOnInit() {
    if (this.data.program) {
      // edit
      this.isEditMode = true;
      this.title = 'Edit academy program';
      this.program = this.data.program;
    } else {
      // create
      this.title = 'Add new academy program';
    }
  }

  public onSubmit() {
    if (this.isEditMode) {
      this.academyProgramService.update(this.program).subscribe(result => {
        this.dialogRef.close('ok');
      });
    } else {
      this.academyProgramService.create(this.program).subscribe(result => {
        this.dialogRef.close('ok');
      });
    }
  }

  public onCancel(form: NgForm) {
    this.dialogRef.close('cancel');
  }
}


