import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { Groups } from 'src/app/shared/models/groups';
import { Subscriber } from 'rxjs';
import { GroupService } from '../group.service';
import { AcademyProgramService } from '../academy-year/academy-program.service';
import { GroupDialogComponent } from './group-dialog.component';
import { MatDialogRef, MAT_DIALOG_DATA, MatTableDataSource, MatPaginator, MatDialog } from '@angular/material';
import { NgForm } from '@angular/forms';
import { WarnDialogComponent } from 'src/app/shared/warn-dialog/warn-dialog';

@Component({
    templateUrl: 'group-sort-dialog.html'
})

export class GroupSortDialogComponent implements OnInit {
    public group: Groups = new Groups();

    public title: string;

    public academyProgramObservable = Subscriber;
    public academyProgramId: number;
    public groups: Groups[] = [];
    columnsToDisplay = ['title', 'Actions'];
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    constructor(
        private groupService: GroupService,
        private academyProgramService: AcademyProgramService,
        private dialogRef: MatDialogRef<GroupDialogComponent>,
        public dialog: MatDialog,
        @Inject(MAT_DIALOG_DATA) public data: any
    ) { }


    public ngOnInit() {
        if (this.data.group) {
            this.title = 'Add new group';
    }
}


    public onSubmit() {
            this.group.academyProgramId = this.academyProgramService.getAcademyProgramId();
            this.groupService.create(this.group).subscribe(result => {
                this.dialogRef.close('ok');
            });
        }

    public onCancel(form: NgForm) {
        this.dialogRef.close('cancel');
    }

    public openWarningDialog(group: Groups): void {
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

    private deleteGroup(group: Groups) {
        this.groupService.delete(group.id, group.academyProgramId)
            .subscribe(result => {
                this.GetAllGroups(this.academyProgramId);
            });
    }

    private GetAllGroups(academyProgramId: number) {
        this.groupService.GetAllGroups(academyProgramId)
            .subscribe(result => {
                this.groups = result;
            });

    }
}
