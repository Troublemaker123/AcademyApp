import { Component, OnInit, Inject } from '@angular/core';
import { Academy } from 'src/app/shared/models/academy';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AcademyService } from '../../../services/academy.service';
import { NgForm, FormControl } from '@angular/forms';
import { SnackbarService } from 'src/app/services/snackbar.service';

@Component({
  selector: 'app-academy-dialog',
  templateUrl: './academy-dialog.component.html'
})
export class AcademyDialogComponent implements OnInit {

  academy: Academy = new Academy();
  title: string;
  isEditMode: boolean = false;

  constructor(
    private academyService: AcademyService,
    private dialogRef: MatDialogRef<AcademyDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _snackBarService: SnackbarService) { }

  ngOnInit() {
    if (this.data.academy) {
      // edit
      this.isEditMode = true;
      this.title = 'Edit Academy';
      this.academy = this.data.academy;
  } else {
      // create
      this.title = 'Add new Academy';
  }
  }

  public onSubmit(form: FormControl) {
    if (!form.valid) {
      return;
    }

    if (this.isEditMode) {
        this.academyService.update(this.academy).subscribe(result => {
            this.dialogRef.close('ok');
            if(form.dirty)
              this._snackBarService.changesSaved();
        });
    } else {
        this.academyService.create(this.academy).subscribe(result => {
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
