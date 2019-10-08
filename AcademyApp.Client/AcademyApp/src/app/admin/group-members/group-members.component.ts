import { Component, OnInit, Inject } from '@angular/core';
import { MatTableDataSource, MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { GroupMembers } from 'src/app/shared/models/groupMembers';
import { Subscription } from 'rxjs';
import { GroupMemberService } from '../group-member.service';
import { AcademyProgramService } from '../academy-year/academy-program.service';
import { WarnDialogComponent } from 'src/app/shared/warn-dialog/warn-dialog';
import { GroupMemberDialogComponent } from './group-member-dialog.component';
import { NgForm } from '@angular/forms';


@Component({
    selector: 'app-group-members',
    templateUrl: 'group-members.component.html'
})

export class GroupMembersComponent implements OnInit {

    public groupDialogMember: GroupMembers = new GroupMembers();
    public academyProgramId: number;
    public groupMember: MatTableDataSource<GroupMembers>;
    public groupMembers: GroupMembers[] = [];
    columnsToDisplay = ['userType', 'Actions'];
    private subscription: Subscription;

    constructor(
        private groupMemberService: GroupMemberService,
        public academyProgramService: AcademyProgramService,
        public dialog: MatDialog,
        private dialogRef: MatDialogRef<GroupMemberDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any
    ) {
        // tslint:disable-next-line:no-shadowed-variable
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
               this.deleteGroupMember(group);
           }
       });
   }

   private deleteGroupMember(groupMembers: GroupMembers) {
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

   public onSubmit() {
        this.groupDialogMember.academyProgramId = this.academyProgramService.getAcademyProgramId();
        this.groupMemberService.create(this.groupDialogMember).subscribe(result => {
            this.dialogRef.close('ok');
        });

}

public onCancel(form: NgForm) {
    this.dialogRef.close('cancel');
}
}
