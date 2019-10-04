import { Component, OnInit } from '@angular/core';
import { MatTableDataSource, MatDialog } from '@angular/material';
import { GroupMembers } from 'src/app/shared/models/groupMembers';
import { Subscription } from 'rxjs';
import { GroupMemberService } from '../group-member.service';
import { AcademyProgramService } from '../academy-year/academy-program.service';
import { WarnDialogComponent } from 'src/app/shared/warn-dialog/warn-dialog';
import { GroupMemberDialogComponent } from './group-member-dialog.component';

@Component({
    selector: 'app-group-members',
    templateUrl: 'group-members.component.html'
})

export class GroupMembersComponent implements OnInit {
    public academyProgramId: number;
    public groupMember: MatTableDataSource<any>;
    public groupMembers: GroupMembers[] = [];
    columnsToDisplay = ['userType', 'actions'];
    private subscription: Subscription;
    constructor(
        private groupMemberService: GroupMemberService,
        public academyProgramService: AcademyProgramService,
        public dialog: MatDialog
    ) {
        this.subscription = this.academyProgramService.getAcademyProgramIdEvent().subscribe(data => {
            this.academyProgramId = data.academyProgramId;
            this.GetAllGroupMembers(this.academyProgramId);
        });
     }

    ngOnInit() {
        this.academyProgramId = this.academyProgramService.getAcademyProgramId();
        if (this.academyProgramId) {
            this.GetAllGroupMembers(this.academyProgramId);
        }
    }

   public openDialog(group: GroupMembers): void {
       const dialogRef = this.dialog.open(GroupMemberDialogComponent, {
           width: '500px',
           disableClose: true,
           data: { group }
       });

       dialogRef.afterClosed().subscribe(result => {
           if (result === 'ok') {
               this.GetAllGroupMembers(this.academyProgramId);
           }
       });
   }

   public openWarningDialog(group: GroupMembers): void {
       const dialogRef = this.dialog.open(WarnDialogComponent, {
           // new Warning Dialog
           width: '300px',
           disableClose: true,
           data: { group }
       });

       dialogRef.afterClosed().subscribe(result => {
           if (result === 'ok') {
               this.deleteGroup(group);
           }
       });
   }

   private deleteGroup(groupMembers: GroupMembers) {
       this.groupMemberService.delete(groupMembers.id, groupMembers.academyProgramId)
           .subscribe(result => {
               this.GetAllGroupMembers(this.academyProgramId);
           });
   }

   private GetAllGroupMembers(academyProgramId: number) {
       this.groupMemberService.GetAllGroupMembers(academyProgramId)
           .subscribe(result => {
               this.groupMembers = result;
           });

   }
}
