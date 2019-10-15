import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Inject, Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';


import { Groups } from 'src/app/shared/models/groups';
import { Subscriber } from 'rxjs';
import { GroupService } from '../group.service';
import { AcademyProgramStateService } from '../academy-program/academy-program-state.service';




@Component({
    templateUrl: 'group-dialog.component.html'
})
export class GroupDialogComponent implements OnInit {

    public group: Groups = new Groups();

    public title: string;

    public academyProgramObservable = Subscriber;

    private isEditMode = false;

    constructor(
        private groupService: GroupService,
        private academyProgramStateService: AcademyProgramStateService,
        private dialogRef: MatDialogRef<GroupDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any
    ) { }


    public ngOnInit() {
        if (this.data.group) {
            // edit
            this.isEditMode = true;
            this.title = 'Edit group';
            this.group = this.data.group;
        } else {
            // create
            this.title = 'Add new group';
        }
    }


    public onSubmit() {

        if (this.isEditMode) {
            this.groupService.update(this.group).subscribe(result => {
                this.dialogRef.close('ok');
            });
        } else {
            this.group.academyProgramId = this.academyProgramStateService.getAcademyProgramId();
            this.groupService.create(this.group).subscribe(result => {
                this.dialogRef.close('ok');
            });
        }
    }

    public onCancel(form: NgForm) {
        this.dialogRef.close('cancel');
    }
}
