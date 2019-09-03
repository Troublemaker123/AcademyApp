import { Component, Inject, OnInit } from '@angular/core';
import { NgForm, FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { AcademyProgram } from 'src/app/shared/models/academyProgram';
import { AdminService } from '../admin.service';

@Component({
  templateUrl: 'academy-year-dialog.component.html'
})
export class AcademyYearDialogComponent implements OnInit {
  public program: AcademyProgram = new AcademyProgram();
  public title: string;

  private isEditMode: boolean = false;

  constructor(
    private adminService: AdminService,
    private dialogRef: MatDialogRef<AcademyYearDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }


  public ngOnInit() {
    if (this.data.program) {
      // edit
      this.isEditMode = true;
      this.title = 'Edit academy program';
      this.program = this.data.program;
    }
    else {
      // create
      this.title = 'Add new academy program';
    }
  }

  public onSubmit() {
    if (this.isEditMode) {
      this.adminService.update(this.program).subscribe(result => {
        this.dialogRef.close('ok');
      });
    } else {
      this.adminService.create(this.program).subscribe(result => {
        this.dialogRef.close('ok');
      });
    }
  }

  public onCancel(form: NgForm) {
    this.dialogRef.close('cancel');
  }
}


