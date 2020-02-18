import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { SnackBarComponent } from '../snack-bar/snack-bar.component';
import { SnackbarService } from 'src/app/services/snackbar.service';

@Component({
  templateUrl: 'warn-dialog.component.html'
})

  export class WarnDialogComponent implements OnInit {

    constructor(private dialogRef: MatDialogRef<any>, private _snackBarService: SnackbarService) { }

    public ngOnInit() {}

    public onDelete() {
      this.dialogRef.close('ok'); 
      // Notify USer that row is deleted
      this._snackBarService.openSnackBar('delete_forever', 'Deleted successfully.');
    }

   public onCancel() {this.dialogRef.close('cancel'); }

}
