import { NgModule } from '@angular/core';
import * as Material from '@angular/material';
import { SnackBarComponent } from './snack-bar/snack-bar.component';

@NgModule({
  imports: [
    Material.MatToolbarModule,
    Material.MatFormFieldModule,
    Material.MatInputModule,
    Material.MatSelectModule,
    Material.MatButtonModule,
    Material.MatTableModule,
    Material.MatIconModule,
    Material.MatPaginatorModule,
    Material.MatDialogModule,
    Material.MatTabsModule,
    Material.MatListModule,
    Material.MatSidenavModule,
    Material.MatCheckboxModule,
    Material.MatDatepickerModule,
    Material.MatNativeDateModule,
    Material.MatSortModule,
    Material.MatTableModule,
    Material.MatOptionModule,
    Material.MatSelectModule,
    Material.MatAutocompleteModule
  ],
  exports: [
    Material.MatToolbarModule,
    Material.MatFormFieldModule,
    Material.MatInputModule,
    Material.MatSelectModule,
    Material.MatButtonModule,
    Material.MatTableModule,
    Material.MatIconModule,
    Material.MatPaginatorModule,
    Material.MatDialogModule,
    Material.MatTabsModule,
    Material.MatListModule,
    Material.MatSidenavModule,
    Material.MatCheckboxModule,
    Material.MatDatepickerModule,
    Material.MatNativeDateModule,
    Material.MatSortModule,
    Material.MatTableModule,
    Material.MatSelectModule,
    Material.MatOptionModule,
    Material.MatAutocompleteModule,
  ],
  declarations: [ SnackBarComponent]
})
export class SharedModule { }
