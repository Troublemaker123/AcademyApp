import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LoginService } from 'src/app/login/login.service';


@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private authenticationService: LoginService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError(err => {

            if (err.status === 401) {
                // auto logout if 401 response returned from api
                this.authenticationService.logout();
                location.reload(true);
            }

            //errors from Fluent Validators
            if (err.status === 405) {
                const fv_errors = err.error.errors;
                let err_msg = '';
                fv_errors.forEach(element => {
                    err_msg += element;          
                });
                return throwError(err_msg);
            }
            const error = err.error.message || err.statusText;
            return throwError(error);
        }))
    }
}