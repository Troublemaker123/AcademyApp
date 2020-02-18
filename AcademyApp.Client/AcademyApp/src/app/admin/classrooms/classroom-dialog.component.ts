import { Component, OnInit, Inject } from '@angular/core';
import { Classroom } from 'src/app/shared/models/classroom';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ClassroomService } from 'src/app/services/classroom.service';
import { FormControl } from '@angular/forms';
import { SnackbarService } from 'src/app/services/snackbar.service';

@Component({
  selector: 'app-classroom-dialog',
  templateUrl: './classroom-dialog.component.html'
})
export class ClassroomDialogComponent implements OnInit {

  classroom: Classroom = new Classroom();
  title: string;
  isEditMode: boolean = false;

  constructor(private _classroomService: ClassroomService,
    private dialogRef: MatDialogRef<ClassroomDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _snackBarService: SnackbarService) { }

  ngOnInit() {
    if (this.data.classroom) {
      // edit
      this.isEditMode = true;
      this.title = 'Edit Classroom';
      this.classroom = this.data.classroom;
  } else {
      // create
      this.title = 'Add new Classroom';
  }
  }

  public onSubmit(form: FormControl) {
    if (!form.valid) {
      return;
    }

    if (this.isEditMode) {
        this._classroomService.update(this.classroom).subscribe(result => {
            this.dialogRef.close('ok');
            if(form.dirty)
            this._snackBarService.changesSaved();
        });
    } else {
        this._classroomService.create(this.classroom).subscribe(result => {
            this.dialogRef.close('ok');
            if(form.dirty)
            this._snackBarService.changesSaved();
        });
    }
}

public onCancel() {
    this.dialogRef.close('cancel');
}

}
