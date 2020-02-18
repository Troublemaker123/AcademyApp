import { Component, OnInit } from '@angular/core';
import { LoginService } from './login.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Guid } from "guid-typescript";

@Component({
  selector: 'app-confirm-email',
  templateUrl: './confirm-email.component.html'
})
export class ConfirmEmailComponent implements OnInit {

  emailConfirmed: boolean = false;
  inputToken: Guid;
  error = '';

  constructor(private _service: LoginService,
    private route: ActivatedRoute,
    private router: Router) { 
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
   this.checkIfTokenValid();
  }

  checkIfTokenValid(){
    this._service.confirmEmail(this.inputToken)
    .subscribe(
      result => {
        this.emailConfirmed = true;
        //clear local storage if someone is already logged in 
        this._service.logout();
      },
      error => {
        this.error = error;
        this.emailConfirmed = false;
      }
    );   
  }

  goToLogin(){

    this.router.navigate(['/login']); 
  }

}
