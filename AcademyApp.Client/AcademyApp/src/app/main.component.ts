import { Component, OnInit } from '@angular/core';
import { MenuItem } from './shared/models/menu-item';
import { User } from './shared/models/user';
import { LoginService } from './login/login.service';
import { Role } from './shared/models/roles';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './main.component.html'
})
export class MenuComponent implements OnInit {

  loading = false;
  currentUser: User;
  filter: number = 0;
  menuItems: MenuItem[] = [];

  allMenuItems: MenuItem[] = [
    { routerLink:"/main/administration/roles", icon:"supervisor_account", title:"Administration", role: Role.Administrator },
    { routerLink:"/main/academymgmt/academy", icon:"work", title:"Academy", role: Role["Academy Employee"] },
    { routerLink:"/main/academyprogrammgmt/groups", icon:"assignment", title:"Year Program", role: Role["Academy Employee"] },
    { routerLink:"/main/mentor", icon:"record_voice_over", title:"Mentor Dashboard", role: Role.Mentor },
    { routerLink:"/main/student", icon:"face", title:"Student Dashboard", role: Role.Student }
  ];
  constructor(private authenticationService: LoginService, private router: Router) {
    if (this.authenticationService.currentUserValue) {      
        this.currentUser = this.authenticationService.currentUserValue; 
        this.filter = Role[`${this.currentUser.userRole}`];
    }
   }

  ngOnInit() {
    this.menuItems = this.allMenuItems.filter(m => m.role === this.filter);
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }

  changePassword(){
    this.router.navigate(['/changepassword']);
  }

}
