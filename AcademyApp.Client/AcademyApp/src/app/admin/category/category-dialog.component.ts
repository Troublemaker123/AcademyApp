import { Component, OnInit, Inject } from '@angular/core';
import { Category } from 'src/app/shared/models/category';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material';
import { FormControl } from '@angular/forms';
import { CategoryService } from '../../services/category.service';
import { SnackbarService } from 'src/app/services/snackbar.service';

@Component({
  selector: 'app-category-dialog',
  templateUrl: './category-dialog.component.html'
})
export class CategoryDialogComponent implements OnInit {

  category: Category = new Category();
  categories: Category[];
  title: string;
  isEditMode: boolean = false;

  constructor( private dialogRef: MatDialogRef<CategoryDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _categoryService: CategoryService,
    private _snackBarService: SnackbarService) { }

  ngOnInit() {

    if (this.data.category) {
      // edit
      this.isEditMode = true;
      this.title = 'Edit category';
      this.category = this.data.category;
  } else {
      // create
      this.title = 'Add new category';
  }
  }

  public onSubmit(form: FormControl) {
    if (!form.valid) {
        return;
    }
    
    if (this.isEditMode) {
        this._categoryService.update(this.category).subscribe(result => {
            this.dialogRef.close('ok');
            if(form.dirty)
            this._snackBarService.changesSaved();
        });
    } else {
        // this.group.academyProgramId = this.academyProgramStateService.getAcademyProgramId();
        this._categoryService.create(this.category).subscribe(result => {
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
