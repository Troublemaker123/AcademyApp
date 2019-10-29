import { Component, OnInit } from '@angular/core';
import { MatDialog, MatTableDataSource } from '@angular/material';
import { Subscription } from 'rxjs/Subscription';

import { Student } from 'src/app/shared/models/student';
import { StudentService } from '../student.service';
import { StudentDialogComponent } from './student-dialog.component';
import { AcademyProgramStateService } from '../academy-program/academy-program-state.service';
import { WarnDialogComponent } from 'src/app/shared/warn-dialog/warn-dialog';


@Component({
    selector: 'app-student',
    templateUrl: './students.component.html'
})
export class StudentsComponent implements OnInit {

    public academyProgramId: number;
    public student: MatTableDataSource<any>;
    public students: Student[] = [];
    columnsToDisplay = ['name', 'lastName', 'emailAdress', 'address', 'dateOfBirth',
    'placeOfBirth', 'mobile', 'country', 'graduationYear', 'dateOfEnrollment', 'gender', 'Actions'];


    private subscription: Subscription;

    constructor(
        private studentService: StudentService,
        public academyProgramStateService: AcademyProgramStateService,
        public dialog: MatDialog
    ) {
        this.subscription = this.academyProgramStateService.getAcademyProgramIdEvent()
            .subscribe(data => {
                this.academyProgramId = data.academyProgramId;
                this.GetAllStudents(this.academyProgramId);
            });
    }


    public ngOnInit() {
        this.academyProgramId = this.academyProgramStateService.getAcademyProgramId();
        if (this.academyProgramId) {
            this.GetAllStudents(this.academyProgramId);
        }

    }

    public openDialog(student: Student): void {
        const dialogRef = this.dialog.open(StudentDialogComponent, {
            width: '500px',
            disableClose: true,
            data: { student }
        });

        dialogRef.afterClosed().subscribe(result => {
            if (result === 'ok') {
                this.GetAllStudents(this.academyProgramId);
            }
        });
    }

    public openWarningDialog(student: Student): void {
        const dialogRef = this.dialog.open(WarnDialogComponent, {
            // new Warning Dialog
            width: '300px',
            disableClose: true,
            data: { student }
        });

        dialogRef.afterClosed().subscribe(result => {
            if (result === 'ok') {
                this.deleteStudent(student);
            }
        });
    }

    private deleteStudent(student: Student) {
        this.studentService.delete(student.id, student.academyProgramId)
            .subscribe(result => {
                this.GetAllStudents(this.academyProgramId);
            });
    }

    private GetAllStudents(academyProgramId: number) {
        this.studentService.GetAllStudents(academyProgramId)
            .subscribe(result => {
                this.students = result;
            });

    }
}
