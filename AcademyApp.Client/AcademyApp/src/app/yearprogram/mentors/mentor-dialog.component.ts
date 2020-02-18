import { Component, Inject, OnInit } from '@angular/core';
import { NgForm, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { Mentor } from 'src/app/shared/models/mentors';
import { MentorService } from '../../services/mentor.service';

import { Subscriber } from 'rxjs';
import { AcademyProgramStateService } from '../../academymgmt/academy-program/academy-program-state.service';
import { SnackbarService } from 'src/app/services/snackbar.service';

@Component({
  templateUrl: 'mentor-dialog.component.html'
})
export class MentorDialogComponent implements OnInit {

  public mentors: Mentor = new Mentor();

  public title: string;

  public academyProgramObservable = Subscriber;

  private isEditMode = false;

  constructor(
    private mentorService: MentorService,
    private academyProgramStateService: AcademyProgramStateService,
    private dialogRef: MatDialogRef<MentorDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _snackBarService: SnackbarService
  ) { }


  public ngOnInit() {
    if (this.data.mentor) {
      // edit
      this.isEditMode = true;
      this.title = 'Edit mentor';
      this.mentors = this.data.mentor;
    } else {
      // create
      this.title = 'Add new mentor';
    }
  }

  public onSubmit(form: FormControl) {
    if (!form.valid) {
      return;
    }

    if (this.isEditMode) {
      this.mentorService.update(this.mentors).subscribe(result => {
        this.dialogRef.close('ok');
      });
    } else {
      this.mentors.academyProgramId = this.academyProgramStateService.getAcademyProgramId();
      this.mentorService.create(this.mentors).subscribe(result => {
        this.dialogRef.close('ok');
        if(form.dirty)
        this._snackBarService.changesSaved();
      });
    }
   
  }

  public onCancel(form: NgForm) {
    this.dialogRef.close('cancel');
  }
}


