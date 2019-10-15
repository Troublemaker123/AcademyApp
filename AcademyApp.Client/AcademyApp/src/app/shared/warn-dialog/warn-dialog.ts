import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';

@Component({
  templateUrl: 'warn-dialog.component.html'
})

  export class WarnDialogComponent implements OnInit {

    constructor(private dialogRef: MatDialogRef<any>) { }

    public ngOnInit() {}

    public onDelete() {this.dialogRef.close('ok'); }

   public onCancel() {this.dialogRef.close('cancel'); }

}
