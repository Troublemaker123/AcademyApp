import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from './login.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html'
})
export class ResetPasswordComponent implements OnInit {

  resetForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';
  btnText: string = "Send Link to Reset";

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: LoginService) { }

  ngOnInit() {
    this.resetForm = this.formBuilder.group({
      username: ['', Validators.required]
    });
  }
   // convenience getter for easy access to form fields
   get f() { return this.resetForm.controls; }

  onSubmit(){
      // stop here if form is invalid
      if (this.resetForm.invalid) {
        this.error = "* Required";
        return;
      }

      this.loading = true;
      this.authenticationService.forgetPassword(this.f.username.value)
      .subscribe(
        userId => {
          this.btnText = "Check your Email!";
          this.error ='';
          //this.router.navigate([`/changepassword/${userId}`]);
        },
        error => {
          this.error = error;
          this.loading = false;
        });
  }

}
