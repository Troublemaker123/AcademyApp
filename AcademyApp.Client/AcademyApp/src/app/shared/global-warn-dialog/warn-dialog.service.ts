import { Observable } from 'rxjs';
import { MatDialogRef, MatDialog } from '@angular/material';
import { Injectable } from '@angular/core';
import { WarnDialogComponent } from './warn-dialog';



@Injectable()
export class DeleteService {

  private dialogRef: MatDialogRef<WarnDialogComponent>;

  constructor(private dialog: MatDialog) { }

  public confirm(title: string): Observable<any> {

    this.dialogRef = this.dialog.open(WarnDialogComponent);

    return this.dialogRef.afterClosed();

  }
}