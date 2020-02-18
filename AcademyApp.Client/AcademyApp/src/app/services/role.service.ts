import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Roles } from '../shared/models/roles';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  public baseApiUrl: string = environment.apiUrl + 'Admin/role/';
  
  constructor(private http: HttpClient) { }

  public getAllRoles(): Observable<Roles[]> {
    return this.http.get<Roles[]>(this.baseApiUrl + 'get-all');
}
public create(role: Roles): Observable<Roles> {
    return this.http.post<Roles>(this.baseApiUrl + 'create', role);
}
public delete(roleId: number): Observable<any> {
    return this.http.delete<any>(`${this.baseApiUrl}delete/${roleId}`);
}
public update(role: Roles): Observable<object> {
    return this.http.put(`${this.baseApiUrl}update`, role);
}
public findById(roleId: number): Observable<Roles> {
    return this.http.get<Roles>(`${this.baseApiUrl}find-by-id/${roleId}`);
}
}
