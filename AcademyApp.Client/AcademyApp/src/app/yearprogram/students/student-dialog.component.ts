import { Component, Inject, OnInit } from '@angular/core';
import { NgForm, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { StudentService } from '../../services/student.service';
import { Student } from 'src/app/shared/models/student';
import { AcademyProgramStateService } from '../../academymgmt/academy-program/academy-program-state.service';
import { AcademyProgram } from 'src/app/shared/models/academyProgram';
import { AcademyProgramService } from 'src/app/services/academy-program.service';
import { SnackbarService } from 'src/app/services/snackbar.service';


@Component({
    templateUrl: 'student-dialog.component.html'
})
export class StudentDialogComponent implements OnInit {

    student: Student = new Student();
    title: string;
    isEditMode = false;
    academyPrograms: AcademyProgram[] = [];

    constructor(
        private studentService: StudentService,
        private academyProgramStateService: AcademyProgramStateService,
        private dialogRef: MatDialogRef<StudentDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        private academyProgramService: AcademyProgramService,
        private _snackBarService: SnackbarService
    ) { }


    public ngOnInit() {
        this.getAllAcademyPrograms();
        
        if (this.data.student) {
            // edit
            this.isEditMode = true;
            this.title = 'Edit student';
            this.student = this.data.student;
          } else {
            // create
            this.title = 'Add new student';
            this.student.academyProgramId = this.academyProgramStateService.getAcademyProgramId();
          }
    }


    public onSubmit(form: FormControl) {
        if (!form.valid) {
            return;
          }

        if (this.isEditMode) {
            this.studentService.update(this.student).subscribe(result => {
                this.dialogRef.close('ok');
                if(form.dirty)
                this._snackBarService.changesSaved();
            });
        } else {
            this.student.academyProgramId = this.academyProgramStateService.getAcademyProgramId();
            this.studentService.create(this.student).subscribe(result => {
                this.dialogRef.close('ok');
                if(form.dirty)
                this._snackBarService.changesSaved();
            });
        }
      
    }

    public onCancel(form: NgForm) {
        this.dialogRef.close('cancel');
    }

    private getAllAcademyPrograms() {
        this.academyProgramService.GetAllAcademyPrograms()
            .subscribe(result => {
                this.academyPrograms = result;
            });
    }
}
