import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { LoginService } from './login.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from '../shared/models/user';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html'
})
export class ChangePasswordComponent implements OnInit {

  changePassForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';

  hideOld = true;
  hideNew = true;
  hideConfirmNew = true;
  btnText: string = "Change";

  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor(private formBuilder: FormBuilder,
    private authenticationService: LoginService,
    private router: Router) { 
      this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
      this.currentUser = this.currentUserSubject.asObservable();
    }

  ngOnInit() {
    this.changePassForm = this.formBuilder.group({
      oldpassword: ['', Validators.required],
      newpassword: ['', Validators.required],
      confirmnewpassword: ['', Validators.required]
    },
    {validator: this.checkPasswords }
    );
  }
 // convenience getter for easy access to form fields
 get f() { return this.changePassForm.controls; }

  // here we have the 'passwords' group
  checkPasswords(group: FormGroup) { 
  let pass = group.get('newpassword').value;
  let confirmPass = group.get('confirmnewpassword').value;

  return pass === confirmPass ? null : { notSame: true }     
  }

   onSubmit(){  

    // stop here if form is invalid or/and passwords did not match
    if (this.changePassForm.invalid) {
      if(this.changePassForm.hasError('notSame'))
      {
        this.error = "* Passwords do not match";
        return;
      }
      this.error = "* Required";
      return;
    }
    this.error = "";
    this.loading = true;

    //now change the password
    this.changePassword(this.currentUserSubject.value.id, this.f.oldpassword.value, this.f.newpassword.value);
   }

   changePassword(userId: number, oldPassword: string, newPassword: string){
    this.authenticationService.changePassword(userId, oldPassword, newPassword)
    .subscribe(
      user => {
        this.submitted = true;
        this.btnText = "New Password Saved!";
        this.authenticationService.logout();
        // logOut and redirect to Login Page
        this.router.navigate(['/login']);
      },
      error => {
        this.error = error;
        this.loading = false;
      }
    );
   }

}
