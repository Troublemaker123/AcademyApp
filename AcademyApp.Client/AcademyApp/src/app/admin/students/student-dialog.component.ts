import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { StudentService } from '../student.service';
import { Student } from 'src/app/shared/models/student';
import { AcademyProgramStateService } from '../academy-program/academy-program-state.service';
import { Subscriber } from 'rxjs';


@Component({
    templateUrl: 'student-dialog.component.html'
})
export class StudentDialogComponent implements OnInit {

    public student: Student = new Student();

    public title: string;

    public academyProgramObservable = Subscriber;

    private isEditMode = false;

    constructor(
        private studentService: StudentService,
        private academyProgramStateService: AcademyProgramStateService,
        private dialogRef: MatDialogRef<StudentDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any
    ) { }


    public ngOnInit() {
        if (this.data.student) {
            this.title = 'Add new student';
        }
    }


    public onSubmit() {

        if (this.isEditMode) {
            this.studentService.update(this.student).subscribe(result => {
                this.dialogRef.close('ok');
            });
        } else {
            this.student.academyProgramId = this.academyProgramStateService.getAcademyProgramId();
            this.studentService.create(this.student).subscribe(result => {
                this.dialogRef.close('ok');
            });
        }
    }

    public onCancel(form: NgForm) {
        this.dialogRef.close('cancel');
    }
}
