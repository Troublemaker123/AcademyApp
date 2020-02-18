import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { SnackBarComponent } from '../shared/snack-bar/snack-bar.component';

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {

  constructor(private _snackBar: MatSnackBar) { }

  public openSnackBar(icon: string, msg: string) {
   return this._snackBar.openFromComponent(SnackBarComponent, {
      duration: 3500,
      // verticalPosition: 'top',     // 'top' | 'bottom'
      // horizontalPosition: 'start', // 'start' | 'center' | 'end' | 'left' | 'right'
      data: {'icon' : icon, 'message': msg }
    });
  }

  public changesSaved() {
    return this._snackBar.openFromComponent(SnackBarComponent, {
       duration: 3500,
       data: {'icon' : 'save', 'message': 'Changes Saved.' }
     });
   }

   public memberAdded() {
    return this._snackBar.openFromComponent(SnackBarComponent, {
       duration: 3500,
       data: {'icon' : 'person_add', 'message': 'New Member Added!' }
     });
   }
}
