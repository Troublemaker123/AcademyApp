import { Component, OnInit, Inject } from '@angular/core';
import { RoleService } from '../../services/role.service';
import { Roles } from 'src/app/shared/models/roles';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { NgForm, FormControl } from '@angular/forms';
import { SnackbarService } from 'src/app/services/snackbar.service';

@Component({
  selector: 'app-role-dialog',
  templateUrl: 'role-dialog.component.html'
})
export class RoleDialogComponent implements OnInit {

  role: Roles = new Roles();
  title: string;
  isEditMode: boolean = false;

  constructor(
    private _roleService: RoleService,
    private dialogRef: MatDialogRef<RoleDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _snackBarService: SnackbarService) { }

  ngOnInit() {
    if (this.data.role) {
      // edit
      this.isEditMode = true;
      this.title = 'Edit Role';
      this.role = this.data.role;
  } else {
      // create
      this.title = 'Add new Role';
  }
  }

  public onSubmit(form: FormControl) {
    if (!form.valid) {
      return;
    }

    if (this.isEditMode) {
        this._roleService.update(this.role).subscribe(result => {
            this.dialogRef.close('ok');
            if(form.dirty)
            this._snackBarService.changesSaved();
        });
    } else {
        this._roleService.create(this.role).subscribe(result => {
            this.dialogRef.close('ok');
            if(form.dirty)
            this._snackBarService.changesSaved();
        });
    }
}

public onCancel(form: NgForm) {
    this.dialogRef.close('cancel');
}

}
