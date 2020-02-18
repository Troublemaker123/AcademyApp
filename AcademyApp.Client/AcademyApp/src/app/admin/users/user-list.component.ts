import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatDialog, MatSnackBar } from '@angular/material';
import { User } from 'src/app/shared/models/user';
import { UserService } from '../../services/user.service';
import { WarnDialogComponent } from 'src/app/shared/warn-dialog/warn-dialog';
import { UserDialogComponent } from './user-dialog.component';
import { BehaviorSubject } from 'rxjs';
import { SnackbarService } from 'src/app/services/snackbar.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html'
})
export class UserListComponent implements OnInit, AfterViewInit {
 
  users = new MatTableDataSource<User>();
  columnsToDisplay = ['userRole','userName', 'emailAdress', 'status', 'Actions', 'Print'];
  error:string='';
  loggedId: number;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  private currentUserSubject: BehaviorSubject<User>;

  constructor(
    private _userService: UserService,
    public dialog: MatDialog,
    private _snackBarService: SnackbarService
  ) { 
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));

  }

  ngOnInit() {
    this.getUsers();
    this.users.paginator = this.paginator;
    this.loggedId= this.currentUserSubject.value.id;
  }

  ngAfterViewInit(): void {
    this.users.sort = this.sort;
  }

  
  private getUsers(){
    this._userService.getAllUsers()
    .subscribe(result => {
      this.users.data = result as User[];
      })
    }

  private deleteAcademy(user: User) {
      this._userService.delete(user.id)
          .subscribe(result => {
            this.getUsers();
          });
  }

  public resendCredentials(user: User){
    this._userService.resendLoginCredentials(user.id)
    .subscribe(() => {

     // Notify Admin where credentials are sent
     this._snackBarService.openSnackBar('info', `Login credentials are sent to ${user.userName} via e-mail.`);
    },
    error =>{
      this.error = error;
    });
  }

  public printCredentials(user: User){
    let icon ='playlist_add_check';
    let message = `Login credentials for user ${user.userName} are sent to printer.`;
    // Notify for printing
    this._snackBarService.openSnackBar(icon, message);
  }

  public openDialog(user: User): void {
    const dialogRef = this.dialog.open(UserDialogComponent, {
        width: '500px',
        disableClose: true,
        data: { user }
    });

    dialogRef.afterClosed().subscribe(result => {
        if (result === 'ok') {
          this.getUsers();
        }
    });
}

public openWarningDialog(user: User): void {
  const dialogRef = this.dialog.open(WarnDialogComponent, {
      // new Warning Dialog
      width: '300px',
      disableClose: true,
      data: { user }
  });

  dialogRef.afterClosed().subscribe(result => {
      if (result === 'ok') {
          this.deleteAcademy(user);
      }
  });
}
}
