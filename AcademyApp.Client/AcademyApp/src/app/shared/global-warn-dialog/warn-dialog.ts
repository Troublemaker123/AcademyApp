
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-delete',
  templateUrl: 'warn-dialog.component.html'
})


  export class WarnDialogComponent implements OnInit {
 form: FormGroup;
  //  public program: AcademyProgram = new AcademyProgram();
  public title: string;
    constructor(
        private formBuilder: FormBuilder,

    //  private adminService: AdminService,
      private dialogRef: MatDialogRef<WarnDialogComponent>,
    @Inject(MAT_DIALOG_DATA) private data: any
    ) { }
  
    public ngOnInit() {
    //  this.program = this.data.program;
    }
  
    public onDelete() {
      debugger;
   //   this.adminService.delete(this.program.id).subscribe(result => {
        this.dialogRef.close('ok');
    //  });
    }
   // public onCancel(form: NgForm) {
   //   this.dialogRef.close('cancel');
  //  }

}