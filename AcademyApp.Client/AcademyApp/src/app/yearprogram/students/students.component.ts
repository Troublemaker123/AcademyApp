import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatDialog, MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { Subscription } from 'rxjs/Subscription';

import { Student } from 'src/app/shared/models/student';
import { StudentService } from '../../services/student.service';
import { StudentDialogComponent } from './student-dialog.component';
import { AcademyProgramStateService } from '../../academymgmt/academy-program/academy-program-state.service';
import { WarnDialogComponent } from 'src/app/shared/warn-dialog/warn-dialog';
import { AddGroupStudentDialogComponent } from '../group-members-list/add-group-student-dialog.component';

@Component({
    selector: 'app-student',
    templateUrl: './students.component.html'
})
export class StudentsComponent implements OnInit, AfterViewInit {

    public academyProgramId: number;
    public student: MatTableDataSource<any>;
    public students = new MatTableDataSource<Student>();// Student[] = [];
    columnsToDisplay = ['name', 'lastName', 'emailAdress', 'address', 'dateOfBirth',
    'isEnrolled', 'mobile', 'country', 'graduationYear', 'dateOfEnrollment', 'gender', 'Actions'];

    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    
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
        let apId = this.academyProgramId;
        if (apId) {
            this.GetAllStudents(apId);
        }
        this.students.paginator = this.paginator;
    }

    ngAfterViewInit(): void {
        //Called after ngAfterContentInit when the component's view has been initialized. Applies to components only.
        //Add 'implements AfterViewInit' to the class.
        this.students.sort = this.sort;
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

    public openGroupDialog(student: Student): void {
        const dialogRef = this.dialog.open(AddGroupStudentDialogComponent, {
           width: '800px',
           disableClose: true,
           data: { student }
       });
        dialogRef.afterClosed().subscribe(result => {
           if (result === 'ok') {
               this.GetAllStudents(this.academyProgramId);
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
                this.students.data = result as Student[];
            });

    }

    public doFilter = (value: string) => {
        this.students.filter = value.trim().toLocaleLowerCase();
      }
}
