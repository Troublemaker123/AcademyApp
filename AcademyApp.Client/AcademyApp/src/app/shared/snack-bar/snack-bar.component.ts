import { Component, OnInit, Inject } from '@angular/core';
import { MAT_SNACK_BAR_DATA } from '@angular/material';

@Component({
  selector: 'app-snack-bar',
  templateUrl: './snack-bar.component.html'
})
export class SnackBarComponent implements OnInit {

  icon: string;
  message: string;
  constructor(@Inject(MAT_SNACK_BAR_DATA) public data: any) { }

  ngOnInit() {
    if(this.data){
      this.icon = this.data.icon;
      this.message = this.data.message;
    }
  }

}
