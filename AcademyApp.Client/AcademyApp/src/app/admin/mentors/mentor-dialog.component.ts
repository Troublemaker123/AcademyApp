import { Component, Inject, OnInit } from '@angular/core';
import { NgForm, FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { Mentor } from 'src/app/shared/models/mentors';
import { MentorService } from '../mentor.service';

@Component({
  templateUrl: 'mentor-dialog.component.html'
})
export class MentorDialogComponent implements OnInit {

  public mentors: Mentor = new Mentor();
  
  public title: string;

  private isEditMode: boolean = false;

  constructor(
    private mentorService: MentorService,
    private dialogRef: MatDialogRef<MentorDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }


  public ngOnInit() {
    if (this.data.mentor) {
      // edit
      this.isEditMode = true;
      this.title = 'Edit mentor';
      this.mentors = this.data.mentor;
    }
    else {
      // create
      this.title = 'Add new mentor';
    }
  }

  public onSubmit() {
    // this.mentors.academyProgramId = 1;
    if (this.isEditMode) {
      this.mentorService.update(this.mentors).subscribe(result => {
        this.dialogRef.close('ok');
      });
    } else {
      this.mentorService.create(this.mentors).subscribe(result => {
        this.dialogRef.close('ok');
      });
    }
  }

  public onCancel(form: NgForm) {
    this.dialogRef.close('cancel');
  }
}


