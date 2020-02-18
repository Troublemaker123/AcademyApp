import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from '../shared/models/user';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { Guid } from "guid-typescript";

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;
  public apiUrl: string = `${environment.apiUrl}Auth`;

  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  login(username: string, password: string) {
    return this.http.post<any>(`${this.apiUrl}/login`, { username, password })
      .pipe(map(user => {
         // login successful if there's a jwt token in the response
         if (user && user.token) {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        localStorage.setItem('currentUser', JSON.stringify(user));
        this.currentUserSubject.next(user);
         }        
        return user;
      }));
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }

  confirmEmail(activationToken: Guid) {
   return this.http.post<any>(`${this.apiUrl}/confirm/${activationToken}`, null)
      .pipe(map( data => {
        return data;
      }));
  }

  forgetPassword(username: string)
  {
    return this.http.post<any>(`${this.apiUrl}/forget/${username}`, null)
      .pipe(map( data => {
        return data;
      }));
  }

  resetPassword(activationToken: string, newPassword: string){
    return this.http.post<any>(`${this.apiUrl}/resetpassword`, {activationToken, newPassword})
      .pipe(map( data => {
        return data;
      }));
  }

  changePassword(userId: number, oldPassword: string, newPassword: string){
    return this.http.post<any>(`${this.apiUrl}/changepassword`, {userId, oldPassword, newPassword})
      .pipe(map( data => {
        return data;
      }));
  }

}
