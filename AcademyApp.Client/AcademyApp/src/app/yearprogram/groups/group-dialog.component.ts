import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Inject, Component, OnInit } from '@angular/core';
import { NgForm, FormControl } from '@angular/forms';


import { Groups } from 'src/app/shared/models/groups';
import { Subscriber } from 'rxjs';
import { GroupService } from '../../services/group.service';
import { AcademyProgramStateService } from '../../academymgmt/academy-program/academy-program-state.service';
import { AcademyProgram } from 'src/app/shared/models/academyProgram';
import { AcademyProgramService } from '../../services/academy-program.service';
import { SnackbarService } from 'src/app/services/snackbar.service';




@Component({
    templateUrl: 'group-dialog.component.html'
})
export class GroupDialogComponent implements OnInit {

    group: Groups = new Groups();
    academyprograms: AcademyProgram[];
    title: string;

    academyProgramObservable = Subscriber;

    private isEditMode = false;

    constructor(
        private groupService: GroupService,
        private _academyProgramService: AcademyProgramService,
        private academyProgramStateService: AcademyProgramStateService,
        private dialogRef: MatDialogRef<GroupDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        private _snackBarService: SnackbarService
    ) { }


    public ngOnInit() {
        this.getAllPrograms();

        if (this.data.group) {
            // edit
            this.isEditMode = true;
            this.title = 'Edit group';
            this.group = this.data.group;
        } else {
            // create
            this.title = 'Add new group';
            this.group.academyProgramId = this.academyProgramStateService.getAcademyProgramId();
        }
    }


    public onSubmit(form: FormControl) {
        if (!form.valid) {
            return;
        }
        
        if (this.isEditMode) {
            this.groupService.update(this.group).subscribe(result => {
                this.dialogRef.close('ok');
                if(form.dirty)
                this._snackBarService.changesSaved();
            });
        } else {
            
            this.groupService.create(this.group).subscribe(result => {
                this.dialogRef.close('ok');
                if(form.dirty)
                this._snackBarService.changesSaved();
            });
        }
       
    }

    public onCancel(form: NgForm) {
        this.dialogRef.close('cancel');
    }

    private getAllPrograms() {
        this._academyProgramService.GetAllAcademyPrograms()
            .subscribe(result => {
                this.academyprograms = result;
            });
    }
}
