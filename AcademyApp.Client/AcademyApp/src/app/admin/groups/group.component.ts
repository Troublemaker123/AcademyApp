import { OnInit, ViewChild, Component } from '@angular/core';
import { GroupService } from '../group.service';
import { MatPaginator, MatSort, MatTableDataSource, MatDialog } from '@angular/material';
import { Groups } from 'src/app/shared/models/groups';
import { Subscription } from 'rxjs';
import { AcademyProgramService } from '../academy-year/academy-program.service';
import { WarnDialogComponent } from 'src/app/shared/warn-dialog/warn-dialog';
import { GroupDialogComponent } from './group-dialog.component';
import { GroupSortDialogComponent } from './group-sort-dialog.component';


@Component({
    selector: 'app-group',
    templateUrl: 'group.component.html'
})

export class GroupComponent implements OnInit {

    public academyProgramId: number;
    public group: MatTableDataSource<any>;
    public groups: Groups[] = [];
    columnsToDisplay = ['title', 'Actions'];
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;

    private subscription: Subscription;

    constructor(
        private groupService: GroupService,
        public academyProgramService: AcademyProgramService,
        public dialog: MatDialog
    ) {
        this.subscription = this.academyProgramService.getAcademyProgramIdEvent()
            .subscribe(data => {
                this.academyProgramId = data.academyProgramId;
                this.GetAllGroups(this.academyProgramId);
            });
    }


    public ngOnInit() {
        this.academyProgramId = this.academyProgramService.getAcademyProgramId();
        if (this.academyProgramId) {
            this.GetAllGroups(this.academyProgramId);
        }

    }

    // tslint:disable-next-line:use-lifecycle-interface
    public ngOnDestroy() {
        // unsubscribe to ensure no memory leaks
        this.subscription.unsubscribe();
    }

    public openGroupDialog(group: Groups): void {
         this.dialog.open(GroupSortDialogComponent, {
            width: '1000px',
            data: { group }
        });
    }



    public openDialog(group: Groups): void {
        const dialogRef = this.dialog.open(GroupDialogComponent, {
            width: '500px',
            disableClose: true,
            data: { group }
        });

        dialogRef.afterClosed().subscribe(result => {
            if (result === 'ok') {
                this.GetAllGroups(this.academyProgramId);
            }
        });
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
