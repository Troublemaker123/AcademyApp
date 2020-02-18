import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatDialog } from '@angular/material';
import { Roles } from 'src/app/shared/models/roles';
import { RoleService } from '../../services/role.service';
import { RoleDialogComponent } from './role-dialog.component';
import { WarnDialogComponent } from 'src/app/shared/warn-dialog/warn-dialog';

@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html'
})
export class RoleListComponent implements OnInit, AfterViewInit {
  
  roles = new MatTableDataSource<Roles>();
  columnsToDisplay = ['description', 'Actions'];

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor(private _roleService: RoleService,
    public dialog: MatDialog) { }

  ngOnInit() {
    this.getRoles();
    this.roles.paginator = this.paginator;
  }

  ngAfterViewInit(): void {
    this.roles.sort = this.sort;
  }

  private getRoles(){
    this._roleService.getAllRoles()
    .subscribe(result => {
      this.roles.data = result as Roles[];
      })
    }


  public openDialog(role: Roles): void {
      const dialogRef = this.dialog.open(RoleDialogComponent, {
          width: '500px',
          disableClose: true,
          data: { role }
      });role

      dialogRef.afterClosed().subscribe(result => {
          if (result === 'ok') {
            this.getRoles();
          }
      });
  }

  public openWarningDialog(role: Roles): void {
    const dialogRef = this.dialog.open(WarnDialogComponent, {
        // new Warning Dialog
        width: '300px',
        disableClose: true,
        data: { role }
    });

    dialogRef.afterClosed().subscribe(result => {
        if (result === 'ok') {
            this.deleteAcademy(role);
        }
    });
}

private deleteAcademy(role: Roles) {
    this._roleService.delete(role.id)
        .subscribe(result => {
          this.getRoles();
        });
}

}
