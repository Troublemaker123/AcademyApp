import { Component, OnInit, Inject } from '@angular/core';
import { GroupMembers } from 'src/app/shared/models/groupMembers';
import { Subscription } from 'rxjs';
import { GroupMemberService } from '../group-member.service';
import { AcademyProgramStateService } from '../academy-program/academy-program-state.service';
import { MAT_DIALOG_DATA, MatDialogRef, MatTableDataSource } from '@angular/material';
import { NgForm } from '@angular/forms';
import { SelectionModel } from '@angular/cdk/collections';
import { Groups } from 'src/app/shared/models/groups';

@Component({
    templateUrl: 'group-member-dialog.component.html'
})

export class GroupMemberDialogComponent implements OnInit {


    public groupMember: GroupMembers = new GroupMembers();
    public groupMembers: GroupMembers[] = [];
    public groupMembersTableData = new MatTableDataSource<GroupMembers>();
    public selectedGroup: Groups;
    displayedColumns = ['select', 'fullName', 'userType'];
    public academyProgramId: number;
    selection = new SelectionModel<GroupMembers>(true, []);

    private subscription: Subscription;

    constructor(
        public groupMemberService: GroupMemberService,
        public academyProgramStateService: AcademyProgramStateService,
        public dialogRef: MatDialogRef<GroupMemberDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any
    ) {
        if (data) {
            this.selectedGroup = data.group;
        }

        this.subscription = this.academyProgramStateService.getAcademyProgramIdEvent()
            .subscribe(x => {
                this.academyProgramId = x.academyProgramId;
                this.GetAllStudentsandMentors(this.academyProgramId);
            });
    }

    ngOnInit() {
        this.academyProgramId = this.academyProgramStateService.getAcademyProgramId();
        if (this.academyProgramId) {
            this.GetAllStudentsandMentors(this.academyProgramId);
        }
    }

    private GetAllStudentsandMentors(academyProgramId: number) {
        this.groupMemberService.GetAllStudentsandMentors(this.selectedGroup.id, academyProgramId)
            .subscribe(result => {
                this.groupMembers = result;
            });
    }

    isAllSelected() {
        const numSelected = this.selection.selected.length;
        const numRows = this.groupMembersTableData.data.length;
        return numSelected === numRows;
    }

    masterToggle() {
        this.isAllSelected() ?
            this.selection.clear() :
            this.groupMembersTableData.data.forEach(row => this.selection.select(row));
    }

    checkboxLabel(row?: GroupMembers): string {
        if (!row) {
            return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
        }
        return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.AddGroupMember}`;
    }

    public onSubmit() {

        if (this.selection.selected.length > 0) {
            const apId = this.academyProgramStateService.getAcademyProgramId();
            this.selection.selected.forEach((member: GroupMembers) => {
                member.academyProgramId = apId;
                if (this.selectedGroup) {
                    member.groupId = this.selectedGroup.id;
                }
            });

            this.groupMemberService.create(this.selection.selected).subscribe(result => {
                this.dialogRef.close('ok');
            });
        }
    }

    public onCancel(form: NgForm) {
        this.dialogRef.close('cancel');
    }
}
