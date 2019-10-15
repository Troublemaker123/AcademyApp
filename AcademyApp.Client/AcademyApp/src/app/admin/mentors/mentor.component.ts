import { Component, OnInit, ViewChild, AfterViewInit, OnDestroy } from '@angular/core';
import { MatPaginator, MatDialog, MatTableDataSource, MatSort } from '@angular/material';
import { Subscription } from 'rxjs/Subscription';

import { Mentor } from 'src/app/shared/models/mentors';
import { MentorService } from '../mentor.service';
import { MentorDialogComponent } from './mentor-dialog.component';
import { AcademyProgramStateService } from '../academy-program/academy-program-state.service';
import { WarnDialogComponent } from 'src/app/shared/warn-dialog/warn-dialog';

@Component({
  selector: 'app-mentor',
  templateUrl: 'mentor.component.html'
})

export class MentorComponent implements OnInit, OnDestroy {

  public academyProgramId: number;
  public mentor = new MatTableDataSource<Mentor>();
  public mentors: Mentor[] = [];
  columnsToDisplay = ['name', 'lastName', 'email', 'telephone', 'specialty', 'yearsOfService', 'Actions'];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  private subscription: Subscription;

  constructor(
    private mentorService: MentorService,
    public academyProgramStateService: AcademyProgramStateService,
    public dialog: MatDialog
  ) {
    this.subscription = this.academyProgramStateService.getAcademyProgramIdEvent()
      .subscribe(data => {
        this.academyProgramId = data.academyProgramId;
        this.GetAllMentors(this.academyProgramId);
      });
  }


  public ngOnInit() {
    this.academyProgramId = this.academyProgramStateService.getAcademyProgramId();
    if (this.academyProgramId) {
        this.GetAllMentors(this.academyProgramId);
  }
  }
  public ngOnDestroy() {
    // unsubscribe to ensure no memory leaks
    this.subscription.unsubscribe();
  }

  public openDialog(mentor: Mentor): void {
    const dialogRef = this.dialog.open(MentorDialogComponent, {
      width: '500px',
      disableClose: true,
      data: { mentor }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'ok') {
        this.GetAllMentors(this.academyProgramId);
      }
    });
  }

  public openWarningDialog(mentor: Mentor): void {
    const dialogRef = this.dialog.open(WarnDialogComponent, {
      // new Warning Dialog
      width: '300px',
      disableClose: true,
      data: { mentors: mentor }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === 'ok') {
        this.deleteMentor(mentor);
      }
    });
  }

  private deleteMentor(mentor: Mentor) {
    this.mentorService.delete(mentor.id, mentor.academyProgramId)
      .subscribe(result => {
        this.GetAllMentors(this.academyProgramId);
      });
  }

  private GetAllMentors(academyProgramId: number) {
    this.mentorService.GetAllMentors(academyProgramId)
      .subscribe(result => {
        this.mentors = result;
      });

  }

}
