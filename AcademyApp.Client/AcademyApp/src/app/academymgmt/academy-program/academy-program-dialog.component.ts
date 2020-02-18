import { Component, Inject, OnInit } from '@angular/core';
import { NgForm, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { AcademyProgram } from 'src/app/shared/models/academyProgram';
import { AcademyProgramService } from '../../services/academy-program.service';
import { Academy } from 'src/app/shared/models/academy';
import { AcademyService } from '../../services/academy.service';
import * as moment from 'moment';
import { SnackbarService } from 'src/app/services/snackbar.service';

@Component({
  templateUrl: 'academy-program-dialog.component.html'
})

export class AcademyYearDialogComponent implements OnInit {

  public program: AcademyProgram = new AcademyProgram();
  public title: string;
  private isEditMode = false;
  academies: Academy[];
  error = '';
 
  constructor(
    private academyProgramService: AcademyProgramService,
    private dialogRef: MatDialogRef<AcademyYearDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private academyService: AcademyService,
    private _snackBarService: SnackbarService
  ) { }

  SundayDisabled = (d: moment.Moment): boolean => {
    const day = d.day();
    // Prevent Sunday from being selected.
    return day !== 0;
  }

  public ngOnInit() {
    this.getAllAcademies();
   
    if (this.data.program) {
      // edit
      this.isEditMode = true;
      this.title = 'Edit Academy Program';
      this.program = this.data.program;
    } else {
      // create
      this.title = 'Add Academy Program';
    }
  }

  public onSubmit(form: FormControl) {

    if (!form.valid) {
      return;
    }

    if (this.isEditMode) {
      this.academyProgramService.update(this.program).subscribe(result => {
        this.dialogRef.close('ok');
        if(form.dirty)
        this._snackBarService.changesSaved();
      },
      error =>
      {       
        this.error = error;
      });
    } else {
      this.academyProgramService.create(this.program).subscribe(result => {
        this.dialogRef.close('ok');
        if(form.dirty)
        this._snackBarService.changesSaved();
      },
      error =>
      {       
        this.error = error;
      });
    }

   
  }

  public onCancel(form: NgForm) {
    this.dialogRef.close('cancel');
  }

  private getAllAcademies() {
    this.academyService.getAllAcademies()
      .subscribe(result => {
        this.academies = result;
      });
  }
}


