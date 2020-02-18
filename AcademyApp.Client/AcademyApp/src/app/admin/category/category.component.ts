import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { Category } from 'src/app/shared/models/category';
import { MatPaginator, MatSort, MatDialog, MatTableDataSource } from '@angular/material';
import { CategoryDialogComponent } from './category-dialog.component';
import { WarnDialogComponent } from 'src/app/shared/warn-dialog/warn-dialog';
import { SubCategoryDialogComponent } from './sub-category-dialog.component';
import { CategoryService } from '../../services/category.service';
import { SubCategory } from 'src/app/shared/models/sub-category';
import { SubCategoryService } from '../../services/sub-category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html'
})
export class CategoryComponent implements OnInit, AfterViewInit {
 

  categories = new MatTableDataSource<Category>();// Category[] =[];
  columnsToDisplay = ['name', 'subcategories', 'Actions'];
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor(public dialog: MatDialog,
    private _categoryService: CategoryService,
    private _subCategoryService: SubCategoryService) { }

  ngOnInit() {
    this.getCategories();
    this.categories.paginator = this.paginator;
  }

  ngAfterViewInit(): void {
    this.categories.sort = this.sort;
  }

  private getCategories(){
    this._categoryService.getAll()
    .subscribe(result => {
      this.categories.data = result as Category[];

      })
    }

  private deleteCategory(category: Category) {
      this._categoryService.delete(category.id)
          .subscribe(() => {
            this.getCategories();
          });
  }

  private deleteSubCategory(sub: Category) {
    this._subCategoryService.delete(sub.id)
        .subscribe(() => {
          this.getCategories();
        });
}

  public openDialog(category: Category): void {
    const dialogRef = this.dialog.open(CategoryDialogComponent, {
        width: '500px',
        disableClose: true,
        data: { category }
    });

    dialogRef.afterClosed().subscribe(result => {
        if (result === 'ok') {
            this.getCategories();
        }
    });
}

public openWarningDialog(category: Category): void {
  const dialogRef = this.dialog.open(WarnDialogComponent, {
      // new Warning Dialog
      width: '300px',
      disableClose: true,
      data: { category }
  });

  dialogRef.afterClosed().subscribe(result => {
      if (result === 'ok') {
         this.deleteCategory(category);
      }
  });
}

public openSubCategoryDialog (category: Category): void {
  const dialogRef = this.dialog.open(SubCategoryDialogComponent, {
     width: '1000px',
     disableClose: true,
     data: { category }
 });
  dialogRef.afterClosed().subscribe(result => {
     if (result === 'ok') {
          this.getCategories();
     }
 });
}

public openDeleteSubcategory(subCategory: SubCategory) {
  const dialogRef = this.dialog.open(WarnDialogComponent, {
    width: '300px',
    disableClose: true,
    data: { subCategory }
  });
 dialogRef.afterClosed().subscribe(result => {
    if (result === 'ok') {
      this.deleteSubCategory(subCategory);
      this.getCategories();
    }
  });
}


  
}
