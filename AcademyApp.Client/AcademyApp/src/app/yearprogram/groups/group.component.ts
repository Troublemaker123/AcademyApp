import { OnInit, ViewChild, Component, AfterViewInit } from '@angular/core';
import { GroupService } from '../../services/group.service';
import { MatPaginator, MatSort, MatTableDataSource, MatDialog } from '@angular/material';
import { Groups } from 'src/app/shared/models/groups';
import { Subscription } from 'rxjs';
import { AcademyProgramStateService } from '../../academymgmt/academy-program/academy-program-state.service';
import { WarnDialogComponent } from 'src/app/shared/warn-dialog/warn-dialog';
import { GroupDialogComponent } from './group-dialog.component';
import { GroupMembersListComponent } from '../group-members-list/group-members-list.component';


@Component({
    selector: 'app-group',
    templateUrl: 'group.component.html'
})

export class GroupComponent implements OnInit, AfterViewInit {
    

    public group: MatTableDataSource<any>;
    public groups = new MatTableDataSource<Groups>(); // Groups[] = [];
    academyProgramId: number;
    columnsToDisplay = ['name', 'academyProgramName', 'Actions'];

    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;

    private subscription: Subscription;

    constructor(
        private groupService: GroupService,
        public academyProgramStateService: AcademyProgramStateService,
        public dialog: MatDialog
    ) {  

        
        this.subscription = this.academyProgramStateService.getAcademyProgramIdEvent()
        .subscribe(x => {
            this.academyProgramId = x.academyProgramId;
            this.GetAllGroups(this.academyProgramId);
        });
     }


    public ngOnInit() {
        this.academyProgramId = this.academyProgramStateService.getAcademyProgramId();
        let apId = this.academyProgramId;
        if (this.academyProgramId) {
            this.GetAllGroups( apId);
        }
        this.groups.paginator = this.paginator;
    }

    ngAfterViewInit(): void {
         this.groups.sort = this.sort;
    }

    public openGroupDialog(group: Groups): void {
         const dialogRef = this.dialog.open(GroupMembersListComponent, {
            width: '1000px',
            disableClose: true,
            data: { group }
        });
        
         dialogRef.afterClosed().subscribe(result => {
            if (result === 'ok') {
                this.GetAllGroups(this.academyProgramId);
            }
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
        this.groupService.delete(group.id)
            .subscribe(result => {
                this.GetAllGroups(this.academyProgramId);
            });
    }

    private GetAllGroups(academyProgramId: number) {
        this.groupService.GetAllGroups(academyProgramId)
            .subscribe(result => {
                this.groups.data = result as Groups[];
            });

    }

    public doFilter = (value: string) => {
        this.groups.filter = value.trim().toLocaleLowerCase();
      }
}
