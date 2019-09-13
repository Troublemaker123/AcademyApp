import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatDialog, MatTableDataSource } from '@angular/material';
import { FormGroup, FormControl, NgForm } from '@angular/forms';
import { Mentor } from 'src/app/shared/models/mentors';
import { MentorService } from '../mentor.service';
import { MentorDialogComponent } from './mentor-dialog.component';
import { MentorWarnDialogComponent } from './mentor-warn-dialog';

@Component({
  selector: 'mentor',
  templateUrl: 'mentor.component.html'
})
export class MentorComponent implements OnInit {
  public mentors: Mentor[] = [];
  columnsToDisplay = ['name', 'lastName', 'specialty','telephone','email','yearsOfService','Actions'];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(
    private mentorService: MentorService,
    public dialog: MatDialog
  ) { }


  public ngOnInit() {
    this.GetAllMentors();
  }

  public openDialog(mentor: Mentor): void {
    const dialogRef = this.dialog.open(MentorDialogComponent, {
      width: '500px',
      disableClose: true,
      data: { mentor: mentor }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'ok') {
        this.GetAllMentors();
      }
    });
  }

  public openWarningDialog(mentors: Mentor): void {
    debugger;
    const dialogRef = this.dialog.open(MentorWarnDialogComponent, {
      // new Warning Dialog
      width: '300px',
      disableClose: true,
      data: { mentors : mentors }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'ok') {
        this.deleteMentor(mentors.id);
      }
    });
  }

  private deleteMentor(mentorId: number) {
    this.mentorService.delete(mentorId)
      .subscribe(result => {
        this.GetAllMentors();
      });
  }

  private GetAllMentors() {
    this.mentorService.GetAllMentors()
      .subscribe(result => {
        this.mentors = result;
      });

  }

};
