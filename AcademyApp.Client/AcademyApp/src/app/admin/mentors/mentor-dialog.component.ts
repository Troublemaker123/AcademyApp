import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { Mentor } from 'src/app/shared/models/mentors';
import { MentorService } from '../mentor.service';

import { Subscriber } from 'rxjs';
import { AcademyProgramStateService } from '../academy-program/academy-program-state.service';

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
    @Inject(MAT_DIALOG_DATA) public data: any
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

  public onSubmit() {
    if (this.isEditMode) {
      this.mentorService.update(this.mentors).subscribe(result => {
        this.dialogRef.close('ok');
      });
    } else {
      this.mentors.academyProgramId = this.academyProgramStateService.getAcademyProgramId();
      this.mentorService.create(this.mentors).subscribe(result => {
        this.dialogRef.close('ok');
      });
    }
  }

  public onCancel(form: NgForm) {
    this.dialogRef.close('cancel');
  }
}


