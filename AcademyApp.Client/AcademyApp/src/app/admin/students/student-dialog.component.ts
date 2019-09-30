import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { StudentService } from '../student.service';
import { Student } from 'src/app/shared/models/student';
import { AcademyProgramService } from '../academy-year/academy-program.service';
import { Subscriber } from 'rxjs';


@Component({
    templateUrl: 'student-dialog.component.html'
})
export class StudentDialogComponent implements OnInit {

    public student: Student = new Student();

    public title: string;

    public academyProgramObservable = Subscriber;

    private isEditMode: boolean = false;

    constructor(
        private studentService: StudentService,
        private academyProgramService: AcademyProgramService,
        private dialogRef: MatDialogRef<StudentDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any
    ) { }


    public ngOnInit() {       
        if (this.data.student) {
            // edit
            this.isEditMode = true;
            this.title = 'Edit student';
            this.student = this.data.student;
        }
        else {
            // create
            this.title = 'Add new student';
        }
    }


    public onSubmit() {
 
        if (this.isEditMode) {
            this.studentService.update(this.student).subscribe(result => {
                this.dialogRef.close('ok');
            });
        } else {
            this.student.academyProgramId = this.academyProgramService.getAcademyProgramId();
            this.studentService.create(this.student).subscribe(result => {
                this.dialogRef.close('ok');
            });
        }
    }

    public onCancel(form: NgForm) {
        this.dialogRef.close('cancel');
    }
}
