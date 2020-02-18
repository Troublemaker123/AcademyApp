import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { User } from '../shared/models/user';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public baseApiUrl: string = environment.apiUrl + 'Admin/user/';

  constructor(private http: HttpClient) { }

  public getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.baseApiUrl}get-all`);
}
public create(user: User): Observable<User> {
    return this.http.post<User>(`${this.baseApiUrl}create`, user);
}
public delete(userId: number): Observable<any> {
    return this.http.delete<any>(`${this.baseApiUrl}delete/${userId}`);
}
public update(user: User): Observable<object> {
    return this.http.put(`${this.baseApiUrl}update`, user);
}
public findById(userId: number): Observable<User> {
    return this.http.get<User>(`${this.baseApiUrl}find-by-id/${userId}`);
}

resendLoginCredentials(userId: number)
{
  return this.http.post<any>(`${environment.apiUrl}Auth/resendlogin/${userId}`, null)
    .pipe(map( data => {
      return data;
    }));
}
}
