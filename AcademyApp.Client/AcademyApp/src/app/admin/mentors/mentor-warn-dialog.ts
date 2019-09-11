import { Component, Inject, OnInit } from '@angular/core';
import { NgForm, FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { MentorService } from '../mentor.service';
import { Mentor } from 'src/app/shared/models/mentors';

@Component({
  templateUrl: 'mentor-warn-dialog.component.html'
})
export class MentorWarnDialogComponent implements OnInit {

  public mentors: Mentor = new Mentor();

  constructor(
    private mentorService: MentorService,
    private dialogRef: MatDialogRef<MentorWarnDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  public ngOnInit() {
    this.mentors = this.data.mentors;
  }

  public onDelete() {
    debugger;
    this.mentorService.delete(this.mentors.id).subscribe(result => {
      this.dialogRef.close('ok');
    });
  }
  public onCancel(form: NgForm) {
    this.dialogRef.close('cancel');
  }
}
