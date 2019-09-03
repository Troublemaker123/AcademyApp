import {Component, OnInit, ViewChild, Inject} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';



@Component({
  selector: 'admin',
  templateUrl: 'admin.component.html'
})
export class AdminComponent implements OnInit {


  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;


  ngOnInit() {
    
  }
}

