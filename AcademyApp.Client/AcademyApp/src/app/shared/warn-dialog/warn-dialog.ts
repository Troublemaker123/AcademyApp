import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { NgForm } from '@angular/forms';

@Component({
  templateUrl: 'warn-dialog.component.html'
})

  export class WarnDialogComponent implements OnInit {

    constructor(private dialogRef: MatDialogRef<any>) { }

    public ngOnInit() {}

    public onDelete() {this.dialogRef.close('ok'); }

   public onCancel(form: NgForm) {this.dialogRef.close('cancel'); }

}
