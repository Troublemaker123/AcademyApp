import { Component, OnInit, Inject } from '@angular/core';
import { SubCategory } from 'src/app/shared/models/sub-category';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Category } from 'src/app/shared/models/category';
import { FormControl } from '@angular/forms';
import { SubCategoryService } from '../../services/sub-category.service';
import { SnackbarService } from 'src/app/services/snackbar.service';

@Component({
  selector: 'app-sub-category-dialog',
  templateUrl: './sub-category-dialog.component.html'
})
export class SubCategoryDialogComponent implements OnInit {

  subcategory: SubCategory = new SubCategory();
  categorySelected: Category;
  title: string;

  constructor( private dialogRef: MatDialogRef<SubCategoryDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _subcategoryService: SubCategoryService,
    private _snackBarService: SnackbarService) { }

  ngOnInit() {
    if (this.data.category) {
      this.title = `Add Sub-Category to ${this.data.category.name}`;
      this.categorySelected = this.data.category;
    }
  }

  public onSubmit(form: FormControl) {
    if (!form.valid) {
      return;
    }

      let newSubCategory = this.subcategory;
      newSubCategory.categoryId = this.categorySelected.id;
      
      this._subcategoryService.create(newSubCategory).subscribe(result => {
        this.dialogRef.close('ok');
        if(form.dirty)
        this._snackBarService.changesSaved();
      });
    

  }
  
  public onCancel() {
    this.dialogRef.close('cancel');
}

}
