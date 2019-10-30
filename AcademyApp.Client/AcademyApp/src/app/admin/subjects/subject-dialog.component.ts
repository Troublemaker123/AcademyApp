import { Component, Inject, OnInit } from '@angular/core';
import { NgForm, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { Subjects } from '../../shared/models/subjects';
import { SubjectService } from '../subject.service';
import { AcademyProgramStateService } from '../academy-program/academy-program-state.service';
import { Subscription } from 'rxjs';
import { MentorService } from '../mentor.service';
import { Mentor } from 'src/app/shared/models/mentors';
import { BasicMentor } from 'src/app/shared/models/basicMentor';


@Component({
  templateUrl: 'subject-dialog.component.html'
})
export class SubjectDialogComponent implements OnInit {
  constructor(
    private subjectService: SubjectService,
    private mentorService: MentorService,
    private academyProgramStateService: AcademyProgramStateService,
    private dialogRef: MatDialogRef<SubjectDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {

    this.subscription = this.academyProgramStateService.getAcademyProgramIdEvent()
      .subscribe(x => {
        this.academyProgramId = x.academyProgramId;
        this.GetAllBasicMentors(this.academyProgramId);
      });
  }

  public subject: Subjects = new Subjects();
  public title: string;
  public academyProgramId: number;
  public mentors: BasicMentor[] = [];
  public selectedMentor: BasicMentor[] = [];
  public subscription: Subscription;
  private isEditMode = false;

  public ngOnInit() {
    if (this.data.subject) {
      // edit
      this.isEditMode = true;
      this.title = 'Edit subject';
      this.subject = this.data.subject;
      this.selectedMentor = this.subject.mentorsList;
      this.academyProgramId = this.academyProgramStateService.getAcademyProgramId();
      if (this.academyProgramId) {
        this.GetAllBasicMentors(this.academyProgramId);
      }
    } else {
      // create
      this.title = 'Add new subject';
      this.academyProgramId = this.academyProgramStateService.getAcademyProgramId();
      if (this.academyProgramId) {
        this.GetAllBasicMentors(this.academyProgramId);
      }
    }
  }
  private GetAllBasicMentors(academyProgramId: number) {
    this.mentorService.GetAllBasicMentors(academyProgramId)
      .subscribe(result => {
        if (this.isEditMode && this.subject.mentorsList !== null && this.subject.mentorsList.length > 0) {
          const savedMentors = this.subject.mentorsList;
          const  tempSelectedMentors: BasicMentor[] = [];
          result.forEach((item: BasicMentor) => {
            const index = savedMentors.findIndex(mentor => mentor.id === item.id);
            if (index !== -1) {
              tempSelectedMentors.push(item);
            }
          });
          this.selectedMentor = tempSelectedMentors;
        }
        this.mentors = result;
      });
  }

  public onSubmit() {
    if (this.isEditMode) {
      this.subject.mentorsList = this.selectedMentor;
      this.subjectService.update(this.subject).subscribe(() => {
        this.dialogRef.close('ok');
      });
    } else {
      this.subject.mentorsList = this.selectedMentor;
      this.subject.academyProgramId = this.academyProgramStateService.getAcademyProgramId();
      this.subjectService.create(this.subject).subscribe(() => {
        this.dialogRef.close('ok');
      });
    }
  }

  displayFn(mentor?: Mentor): string | undefined {
    return mentor ? mentor.name : undefined;
  }

  public onCancel(form: NgForm) {
    this.dialogRef.close('cancel');
  }
}
