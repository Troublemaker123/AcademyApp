import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { MatPaginator, MatDialog, MatSort, MatTableDataSource } from '@angular/material';
import { Subscription } from 'rxjs/Subscription';

import { Student } from 'src/app/shared/models/student';
import { StudentService } from '../student.service';
import { StudentDialogComponent } from './student-dialog.component';
import { AcademyProgramService } from '../academy-year/academy-program.service';
import { WarnDialogComponent } from 'src/app/shared/warn-dialog/warn-dialog';


@Component({
    selector: 'student',
    templateUrl: './students.component.html'
})
export class StudentsComponent implements OnInit, OnDestroy {

    public academyProgramId: number;
    public student: MatTableDataSource<any>;
    public students: Student[] = [];
    columnsToDisplay = ['name', 'lastName', 'emailAdress', 'address', 'dateOfBirth', 'placeOfBirth', 'mobile', 'country', 'graduationYear', 'dateOfEnrollment', 'gender', 'Actions'];
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;

    private subscription: Subscription;

    constructor(
        private studentService: StudentService,
        public academyProgramService: AcademyProgramService,
        public dialog: MatDialog
    ) {
        this.subscription = this.academyProgramService.getAcademyProgramIdEvent()
            .subscribe(data => {
                this.academyProgramId = data.academyProgramId;
                this.GetAllStudents(this.academyProgramId)
            });
    }


    public ngOnInit() {
        this.academyProgramId = this.academyProgramService.getAcademyProgramId();
        if (this.academyProgramId) {
            this.GetAllStudents(this.academyProgramId);
        }

    }

    public ngOnDestroy() {
        // unsubscribe to ensure no memory leaks
        this.subscription.unsubscribe();
    }



    public openDialog(student: Student): void {
        const dialogRef = this.dialog.open(StudentDialogComponent, {
            width: '500px',
            disableClose: true,
            data: { student: student }
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
            data: { student: student }
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
