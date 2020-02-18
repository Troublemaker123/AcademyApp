import { Component, OnInit, ViewChild, Inject, AfterViewInit } from '@angular/core';
import { GroupMemberService } from '../../services/group-member.service';
import { MatPaginator, MatSort, MatDialogRef, MatDialog, MAT_DIALOG_DATA, MatTableDataSource } from '@angular/material';
import { WarnDialogComponent } from 'src/app/shared/warn-dialog/warn-dialog';
import { GroupList } from 'src/app/shared/models/groupList';
import { Groups } from 'src/app/shared/models/groups';

@Component({
  selector: 'app-group-members-list',
  templateUrl: './group-members-list.component.html'
})
export class GroupMembersListComponent implements OnInit, AfterViewInit {

  public groupmembers = new MatTableDataSource<GroupList>(); //GroupList[];
  columnsToDisplay = ['userType', 'fullName', 'Actions'];
  group: Groups = this.data.group; 

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor(private _groupMembersService: GroupMemberService,
    public dialogRef: MatDialogRef<GroupMembersListComponent>,
    public dialog: MatDialog,
    @Inject(MAT_DIALOG_DATA) private data: any) { 
      
    }

  ngOnInit() {
    this.getMembersPerGroup(this.group.id);
    this.groupmembers.paginator = this.paginator;
  }

  ngAfterViewInit(): void {
    this.groupmembers.sort = this.sort;
  }

  private getMembersPerGroup(groupId: number)
  {
    this._groupMembersService.GetAllGroupMembers(groupId)
    .subscribe(result => {
        this.groupmembers.data = result as GroupList[];
    });
  }

  private deleteGroupMember(groupMember: GroupList) {
    this._groupMembersService.delete(groupMember.id, groupMember.userTypeId)
        .subscribe(result => {
            this.getMembersPerGroup(this.group.id);
        });
}

  public openWarningDialog(groupMember: GroupList): void {
    const dialogRef = this.dialog.open(WarnDialogComponent, {
        // new Warning Dialog
        width: '300px',
        disableClose: true,
        data: { groupMember }
    });

    dialogRef.afterClosed().subscribe(result => {
        if (result === 'ok') {
            this.deleteGroupMember(groupMember);
        }
    });
}

  public onCancel() {
    this.dialogRef.close('cancel');
  }

  public doFilter = (value: string) => {
    this.groupmembers.filter = value.trim().toLocaleLowerCase();
  }

}
