import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { Classroom } from 'src/app/shared/models/classroom';
import { MatTableDataSource, MatPaginator, MatSort, MatDialog } from '@angular/material';
import { ClassroomService } from 'src/app/services/classroom.service';
import { WarnDialogComponent } from 'src/app/shared/warn-dialog/warn-dialog';
import { ClassroomDialogComponent } from './classroom-dialog.component';

@Component({
  selector: 'app-classroom',
  templateUrl: './classroom.component.html'
})
export class ClassroomComponent implements OnInit, AfterViewInit {
 
  classrooms = new MatTableDataSource<Classroom>();
  columnsToDisplay = ['name','location', 'actions', 'locationmap'];

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor(private _classroomService:ClassroomService,
    public dialog: MatDialog) { }

  ngOnInit() {
    this.getClassRooms();
    this.classrooms.paginator = this.paginator;
  }

  ngAfterViewInit(): void {
   this.classrooms.sort = this.sort;
  }

  private getClassRooms(){
    this._classroomService.getAll()
    .subscribe(result => {
      this.classrooms.data = result as Classroom[];
      })
  }

  public openDialog(classroom: Classroom): void {
    const dialogRef = this.dialog.open(ClassroomDialogComponent, {
        width: '500px',
        disableClose: true,
        data: { classroom }
    });

    dialogRef.afterClosed().subscribe(result => {
        if (result === 'ok') {
          this.getClassRooms();
        }
    });
}

public openWarningDialog(classroom: Classroom): void {
  const dialogRef = this.dialog.open(WarnDialogComponent, {
      // new Warning Dialog
      width: '300px',
      disableClose: true,
      data: { classroom }
  });

  dialogRef.afterClosed().subscribe(result => {
      if (result === 'ok') {
          this.deleteClassRoom(classroom);
      }
  });
}

private deleteClassRoom(classroom: Classroom) {
  this._classroomService.delete(classroom.id)
      .subscribe(result => {
        this.getClassRooms();
      });
}


}
