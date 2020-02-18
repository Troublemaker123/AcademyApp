import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { Academy } from 'src/app/shared/models/academy';
import { AcademyService } from '../../services/academy.service';
import { MatDialog, MatSort, MatPaginator, MatTableDataSource } from '@angular/material';
import { AcademyDialogComponent } from './academy-dialog/academy-dialog.component';
import { WarnDialogComponent } from 'src/app/shared/warn-dialog/warn-dialog';


@Component({
  selector: 'app-acadmylist',
  templateUrl: './acadmylist.component.html'
})
export class AcadmylistComponent implements OnInit, AfterViewInit {
 

  academy: MatTableDataSource<any>;
  academies = new MatTableDataSource<Academy>();// Academy[];
  columnsToDisplay = ['name', 'description', 'Actions'];

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor(
    private _academyService: AcademyService,
    public dialog: MatDialog) { }

  ngOnInit() {
      this.getAllAcademies();
      this.academies.paginator = this.paginator;
  }

  ngAfterViewInit(): void {
    this.academies.sort = this.sort;
  }

  private getAllAcademies(){
    this._academyService.getAllAcademies()
    .subscribe(result => {
      this.academies.data = result as Academy[];
      })
    }


  public openDialog(academy: Academy): void {
      const dialogRef = this.dialog.open(AcademyDialogComponent, {
          width: '500px',
          disableClose: true,
          data: { academy }
      });

      dialogRef.afterClosed().subscribe(result => {
          if (result === 'ok') {
            this.getAllAcademies();
          }
      });
  }

  public openWarningDialog(academy: Academy): void {
    const dialogRef = this.dialog.open(WarnDialogComponent, {
        // new Warning Dialog
        width: '300px',
        disableClose: true,
        data: { academy }
    });

    dialogRef.afterClosed().subscribe(result => {
        if (result === 'ok') {
            this.deleteAcademy(academy);
        }
    });
}

private deleteAcademy(academy: Academy) {
    this._academyService.delete(academy.id)
        .subscribe(result => {
          this.getAllAcademies();
        });
}

}
