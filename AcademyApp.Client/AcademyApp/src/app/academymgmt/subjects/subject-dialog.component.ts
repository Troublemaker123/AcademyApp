import { Component, Inject, OnInit } from '@angular/core';
import { NgForm, FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { Subjects } from '../../shared/models/subjects';
import { SubjectService } from '../../services/subject.service';
import { AcademyProgramStateService } from '../academy-program/academy-program-state.service';
import { Subscription } from 'rxjs';
import { Mentor } from 'src/app/shared/models/mentors';
import { BasicMentor } from 'src/app/shared/models/basicMentor';
import { AcademyService } from '../../services/academy.service';
import { Academy } from 'src/app/shared/models/academy';
import { SnackbarService } from 'src/app/services/snackbar.service';


@Component({
  templateUrl: 'subject-dialog.component.html'
})
export class SubjectDialogComponent implements OnInit {
  form: FormGroup;
  submitted = false;

  public subject: Subjects = new Subjects();
  public title: string;
  //public academyId: number;

  private isEditMode = false;
  academies: Academy[] = [];

  constructor(
    private subjectService: SubjectService,
    private dialogRef: MatDialogRef<SubjectDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private academyService:AcademyService,
    private _snackBarService: SnackbarService
  ) {  }

  public ngOnInit() {
    this.getAcademies();

    if (this.data.subject) {
      // edit
      this.isEditMode = true;
      this.title = 'Edit subject';
      this.subject = this.data.subject;   
    } else {
      // create
      this.title = 'Add new subject';
      if(this.data.academy){
      this.subject.academyId = this.data.academy;}
    }
  }

  private getAcademies()
  {
    this.academyService.getAllAcademies().subscribe(result => {
      this.academies = result;
    });
  }

  public onSubmit(form: FormControl) {
    if (!form.valid) {
      return;
    }

    

    if (this.isEditMode) {
        this.subjectService.update(this.subject).subscribe(() => {
          this.dialogRef.close('ok');
          if(form.dirty)
          this._snackBarService.changesSaved();
        });   
    } else {
        this.subjectService.create(this.subject).subscribe(() => {
          this.dialogRef.close('ok');
          if(form.dirty)
          this._snackBarService.changesSaved();
        });       
    }
   
  }

  // displayFn(mentor?: Mentor): string | undefined {
  //   return mentor ? mentor.firstName : undefined;
  // }

  public onCancel(form: NgForm) {
    this.dialogRef.close('cancel');
  }
}
