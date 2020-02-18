import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Classroom } from '../shared/models/classroom';


@Injectable({
  providedIn: 'root'
})
export class ClassroomService {

  public baseApiUrl: string = environment.apiUrl + 'Admin/classroom/';
  
  constructor(private http: HttpClient) { }

  public getAll(): Observable<Classroom[]> {
    return this.http.get<Classroom[]>(this.baseApiUrl + 'get-all');
}
public create(classroom: Classroom): Observable<Classroom> {
    return this.http.post<Classroom>(this.baseApiUrl + 'create', classroom);
}
public delete(classroomId: number): Observable<any> {
    return this.http.delete<any>(`${this.baseApiUrl}delete/${classroomId}`);
}
public update(classroom: Classroom): Observable<object> {
    return this.http.put(`${this.baseApiUrl}update`, classroom);
}
public findById(classroomId: number): Observable<Classroom> {
    return this.http.get<Classroom>(`${this.baseApiUrl}find-by-id/${classroomId}`);
}
}
