import { Component, Inject, OnInit } from '@angular/core';
import { NgForm, FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { AcademyProgram } from 'src/app/shared/models/academyProgram';
import { AdminService } from '../admin.service';

@Component({
  templateUrl: 'academy-year-warn-dialog.component.html'
})
export class AcademyYearWarnDialogComponent implements OnInit {

  public program: AcademyProgram = new AcademyProgram();

  constructor(
    private adminService: AdminService,
    private dialogRef: MatDialogRef<AcademyYearWarnDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  public ngOnInit() {
    this.program = this.data.program;
  }

  public onDelete() {
    debugger;
    this.adminService.delete(this.program.id).subscribe(result => {
      this.dialogRef.close('ok');
    });
  }
  public onCancel(form: NgForm) {
    this.dialogRef.close('cancel');
  }
}
