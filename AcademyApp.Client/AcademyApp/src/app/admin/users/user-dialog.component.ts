import { Component, OnInit, Inject } from '@angular/core';
import { User } from 'src/app/shared/models/user';
import { UserService } from '../../services/user.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { RoleService } from '../../services/role.service';
import { Roles } from 'src/app/shared/models/roles';
import { NgForm, FormControl } from '@angular/forms';
import { SnackbarService } from 'src/app/services/snackbar.service';

@Component({
  selector: 'app-user-dialog',
  templateUrl: './user-dialog.component.html'
})
export class UserDialogComponent implements OnInit {

  user: User = new User();
  roles: Roles[];
  title: string;
  isEditMode: boolean = false;
  disableRoleChange: boolean = false;
  error: string = '';
  constructor(
    private _userService: UserService,
    private _roleService: RoleService,
    private dialogRef: MatDialogRef<UserDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _snackBarService: SnackbarService) { }

  ngOnInit() {
    this.getRoles();
    if (this.data.user) {
      // edit
      this.isEditMode = true;
      this.title = 'Edit User';
      this.user = this.data.user;
      // don't allow changing Role if it is saved as Student/Mentor
      //if(this.data.user.userRole.trim().toLowerCase() == 'student' || this.data.user.userRole.trim().toLowerCase() == 'mentor')
      // don't allow changing Role after creating User
      this.disableRoleChange = true;
    } else {
      // create
      this.title = 'Add User';
    }
  }
  public onSubmit(form: FormControl) {
    if (!form.valid) {
      return;
    }

    if (this.isEditMode) {
      this._userService.update(this.user).subscribe(result => {
        this.dialogRef.close('ok');
        if(form.dirty)
        this._snackBarService.changesSaved();
      },
      error =>
      {
        this.error = error;
      });
    } else {
      this._userService.create(this.user).subscribe(result => {
        this.dialogRef.close('ok');
        if(form.dirty)
        this._snackBarService.changesSaved();
      },
      error =>
      {
        this.error = error;
      });
    }

   
  }

  public onCancel(form: NgForm) {
    this.dialogRef.close('cancel');
  }

  private getRoles() {
    this._roleService.getAllRoles()
      .subscribe(result => {
        this.roles = result;
      });
  }

}
