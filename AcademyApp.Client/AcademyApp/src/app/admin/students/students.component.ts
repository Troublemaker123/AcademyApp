import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { Student } from 'src/app/shared/models/student';
import { MatPaginator, MatDialog, MatSort, MatTableDataSource } from '@angular/material';
import { StudentService } from '../student.service';
import { StudentDialogComponent } from './student-dialog.component';
import { StudentWarnDialogComponent } from './student-warn-dialog';


@Component({
    selector: 'student',
    templateUrl: './students.component.html'
})
export class StudentsComponent implements OnInit {
  

   public student : MatTableDataSource<any>;


    public students: Student[] = [];
    columnsToDisplay = ['name', 'lastName', 'mobile', 'gender', 'country', 'graduationYear', 'emailAdress', 'dateOfBirth', 'dateOfEnrollment', 'placeOfBirth', 'Actions'];
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, {static: true}) sort: MatSort;
    constructor(
        private studentService: StudentService,
        public dialog: MatDialog
    ) { }


    public ngOnInit() {
        this.GetAllStudents();
        // this.studentService.GetAllStudents().subscribe(
        //     list =>{
        //         let array = list.map(item =>{
        //             return{
        //                 $id :item.id,
        //             ...item.name.
        //             };
        //         });
        //         this.student = new MatTableDataSource(array);
        //         this.student.sort = this.sort;
        //     });
    }
    
    // ngAfterViewInit(): void {
    //     this.student.sort = this.sort;
    //  }

    //  public loadStudents() {
    //     this.studentService.GetAllStudents().subscribe(result => {
    //         this.student.data = result;
    //     });
    //  }

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
        const dialogRef = this.dialog.open(StudentWarnDialogComponent, {
            // new Warning Dialog
            width: '300px',
            disableClose: true,
            data: { student: student }
        });

        dialogRef.afterClosed().subscribe(result => {
            if (result === 'ok') {
                this.deleteStudent(student.id);
            }
        });
    }

    private deleteStudent(studentId: number) {
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
