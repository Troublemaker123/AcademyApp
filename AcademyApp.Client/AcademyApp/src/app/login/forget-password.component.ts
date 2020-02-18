import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from './login.service';

@Component({
  selector: 'app-forget-password',
  templateUrl: './forget-password.component.html'
})
export class ForgetPasswordComponent implements OnInit {

  forgetForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';
  hideNew = true;
  hideConfirmNew = true;
  inputToken: string;


  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: LoginService) { 
      this.route.params.subscribe(params =>
        {    
          if(params.token !== null)
          {// get Token
            this.inputToken = params.token;           
          }
          else{
            this.router.navigate(['/error']); 
          }           
        }) ;
    }

  ngOnInit() {
    // if someone is logged 
    localStorage.clear();
    
    this.forgetForm = this.formBuilder.group(
      {
      newpassword: ['', Validators.required],
      confirmnewpassword: ['', Validators.required]
      },
      {validator: this.checkPasswords }
    );
  }
  
   // convenience getter for easy access to form fields
  get f() { return this.forgetForm.controls; }

   // here we have the 'passwords' group
   checkPasswords(group: FormGroup) { 
    let pass = group.get('newpassword').value;
    let confirmPass = group.get('confirmnewpassword').value;
  
    return pass === confirmPass ? null : { notSame: true }     
    }

    onSubmit(){  

      // stop here if form is invalid or/and passwords did not match
      if (this.forgetForm.invalid) {
        if(this.forgetForm.hasError('notSame'))
        {
          this.error = "* Passwords do not match";
          return;
        }
        this.error = "* Required";
        return;
      }
      this.error = "";     
      this.loading = true;

      // ////now change the password
      this.resetPassword(this.inputToken, this.f.newpassword.value);
     }

     resetPassword(activationToken: string, newPassword: string){
      this.authenticationService.resetPassword(activationToken, newPassword)
      .subscribe(
        user => {
          this.submitted = true;
          this.router.navigate(['/login']);
        },
        error => {
          this.error = error;
          this.loading = false;
        }
      );
     }

}
