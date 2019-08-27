import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator } from '@angular/material';
import { AdminService } from '../admin.service';
import { AcademyProgram } from '../../shared/models/academyProgram';


@Component({
  selector: 'graduate-year',
  templateUrl: 'graduate-year.component.html'
})
export class GraduateYearComponent implements OnInit {

  public displayedColumns: string[] = ['position', 'name', 'weight', 'symbol', 'edit', 'delete'];
  public dataSource = new MatTableDataSource<PeriodicElement>(ELEMENT_DATA);
  public programs: AcademyProgram[] = [];

  constructor(private adminService: AdminService) {
  }

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;


  ngOnInit() {
    this.dataSource.paginator = this.paginator;
    this.getAllPrograms();
  }

  private getAllPrograms() {
    this.adminService.GetAllAcademyPrograms()
      .subscribe(result => {
        this.programs = result;
      });
  }

  private createProgram(model: AcademyProgram) {
    //this.adminService.create(model)
  }
}

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
  edit: string;
  delete: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H', edit: 'Edit', delete: "Delete" },
  { position: 2, name: 'Helium', weight: 4.0026, symbol: 'He', edit: 'Edit', delete: "Delete" },
  { position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li', edit: 'Edit', delete: "Delete" },
  { position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be', edit: 'Edit', delete: "Delete" },
  { position: 5, name: 'Boron', weight: 10.811, symbol: 'B', edit: 'Edit', delete: "Delete" },
  { position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C', edit: 'Edit', delete: "Delete" },
  { position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N', edit: 'Edit', delete: "Delete" },
  { position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O', edit: 'Edit', delete: "Delete" },
  { position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F', edit: 'Edit', delete: "Delete" },
  { position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne', edit: 'Edit', delete: "Delete" },
  { position: 11, name: 'Sodium', weight: 22.9897, symbol: 'Na', edit: 'Edit', delete: "Delete" },
  { position: 12, name: 'Magnesium', weight: 24.305, symbol: 'Mg', edit: 'Edit', delete: "Delete" },
  { position: 13, name: 'Aluminum', weight: 26.9815, symbol: 'Al', edit: 'Edit', delete: "Delete" },
  { position: 14, name: 'Silicon', weight: 28.0855, symbol: 'Si', edit: 'Edit', delete: "Delete" },
  { position: 15, name: 'Phosphorus', weight: 30.9738, symbol: 'P', edit: 'Edit', delete: "Delete" },
  { position: 16, name: 'Sulfur', weight: 32.065, symbol: 'S', edit: 'Edit', delete: "Delete" },
  { position: 17, name: 'Chlorine', weight: 35.453, symbol: 'Cl', edit: 'Edit', delete: "Delete" },
  { position: 18, name: 'Argon', weight: 39.948, symbol: 'Ar', edit: 'Edit', delete: "Delete" },
  { position: 19, name: 'Potassium', weight: 39.0983, symbol: 'K', edit: 'Edit', delete: "Delete" },
  { position: 20, name: 'Calcium', weight: 40.078, symbol: 'Ca', edit: 'Edit', delete: "Delete" },
];