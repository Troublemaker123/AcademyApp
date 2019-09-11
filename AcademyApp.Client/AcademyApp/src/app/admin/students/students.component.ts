import { Component, OnInit, ViewChild } from '@angular/core';
import { Student } from 'src/app/shared/models/student';
import { MatPaginator, MatDialog } from '@angular/material';
import { StudentService } from '../student.service';
import { StudentDialogComponent } from './student-dialog.component';
import { StudentWarnDialogComponent } from './student-warn-dialog';

@Component({
    selector: 'student',
    templateUrl: './students.component.html'
})
export class StudentsComponent implements OnInit {

    public students: Student[] = [];
       columnsToDisplay = ['name', 'lastName','mobile','gender','country','graduationYear','emailAdress','dateOfBirth','dateOfEnrollment','placeOfBirth','Actions'];
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

    constructor(
        private studentService: StudentService,
        public dialog: MatDialog
    ) { }


    public ngOnInit() {
        this.GetAllStudents();
    }

    public openDialog(student: Student): void {
        const dialogRef = this.dialog.open(StudentDialogComponent, {
            width: '500px',
            disableClose: true,
            data: { student: student }
        });

        dialogRef.afterClosed().subscribe(result => {
            if (result === 'ok') {
                this.GetAllStudents();
            }
        });
    }

    public openWarningDialog(student: Student): void {
        debugger;
        const dialogRef = this.dialog.open(StudentWarnDialogComponent, {
            // new Warning Dialog
            width: '300px',
            disableClose: true,
            data: { student: student }
        });

        dialogRef.afterClosed().subscribe(result => {
            if (result === 'ok') {
                this.deleteProgram(student.id);
            }
        });
    }

    private deleteProgram(studentId: number) {
        this.studentService.delete(studentId)
            .subscribe(result => {
                this.GetAllStudents();
            });
    }

    private GetAllStudents() {
        this.studentService.GetAllStudents()
            .subscribe(result => {
                this.students = result;
            });

    }
}
