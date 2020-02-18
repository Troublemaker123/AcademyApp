import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { LoginService } from 'src/app/login/login.service';
import { Role } from '../models/roles';

@Injectable({ providedIn: 'root' })
export class RoleAccessGuard implements CanActivate {
    constructor(
        private router: Router,
        private authenticationService: LoginService
    ) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const currentUser = this.authenticationService.currentUserValue;
        if (currentUser) {

            let roleId = Role[currentUser.userRole];

            // check if route is restricted by role
            if (route.data.roles && route.data.roles.indexOf(roleId) !== -1) {
                // role not authorised so redirect to home page
                return true;
            }

            let routeName: string = '/main';

            switch (roleId) {
                case Role.Administrator:
                    routeName += '/administration';
                    break;
                case Role["Academy Employee"]:
                    routeName += '/academymgmt';
                    break;
                case Role.Mentor:
                    routeName += '/mentor';
                    break;
                case Role.Student:
                    routeName += '/student';
                    break;
            }

            this.router.navigate([routeName]);
        }
        return false;
    }
}