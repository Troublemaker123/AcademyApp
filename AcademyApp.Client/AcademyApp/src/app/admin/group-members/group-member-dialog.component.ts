import { Component, OnInit, Inject } from '@angular/core';
import { GroupMembers } from 'src/app/shared/models/groupMembers';
import { Subscription } from 'rxjs';
import { GroupMemberService } from '../group-member.service';
import { AcademyProgramService } from '../academy-year/academy-program.service';
import { MAT_DIALOG_DATA, MatDialogRef, MatTableDataSource } from '@angular/material';
import { NgForm } from '@angular/forms';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
    templateUrl: 'group-member-dialog.component.html'
})

export class GroupMemberDialogComponent implements OnInit {


    public groupMember: GroupMembers = new GroupMembers();
    public groupMembers: GroupMembers[] = [];
    public groupMembersTableData = new MatTableDataSource<GroupMembers>();
    displayedColumns = ['select', 'fullName', 'userType'];
    public academyProgramId: number;
    selection = new SelectionModel<GroupMembers>(true, []);

    private subscription: Subscription;

    constructor(
        public groupMemberService: GroupMemberService,
        public academyProgramService: AcademyProgramService,
        public dialogRef: MatDialogRef<GroupMemberDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any
    ) {
        this.subscription = this.academyProgramService.getAcademyProgramIdEvent()
        .subscribe(x => {
            this.academyProgramId = x.academyProgramId;
            this.GetAllStudentsandMentors(this.academyProgramId);
        });
    }

    ngOnInit() {
        this.academyProgramId = this.academyProgramService.getAcademyProgramId();
        if (this.academyProgramId) {
            this.GetAllStudentsandMentors(this.academyProgramId);
        }
    }

    private GetAllStudentsandMentors(academyProgramId: number) {
        this.groupMemberService.GetAllStudentsandMentors(academyProgramId)
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
        return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.fullName + 1}`;
    }

    public onSubmit() {
        this.groupMember.academyProgramId = this.academyProgramService.getAcademyProgramId();
        this.groupMemberService.create(this.groupMember).subscribe(result => {
            this.dialogRef.close('ok');
        });
    }

    public onCancel(form: NgForm) {
        this.dialogRef.close('cancel');
    }
}
