import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Subjects } from '../shared/models/subjects';


@Injectable()
export class SubjectService {

    public baseApiUrl: string = environment.apiUrl + 'Employee/subject/';

    constructor(private http: HttpClient) { }

    public GetAllSubjects(academyId: number): Observable<Subjects[]> {
        return this.http.get<Subjects[]>(`${this.baseApiUrl}get-all/${academyId}`);
    }
    public create(subject: Subjects): Observable<Subjects> {
        return this.http.post<Subjects>(`${this.baseApiUrl}create`, subject);
    }
    public delete(subjectId: number): Observable<any> {
        return this.http.delete<any>(`${this.baseApiUrl}delete/${subjectId}`);
    }
    public update(value: any): Observable<object> {
        return this.http.put(`${this.baseApiUrl}update`, value);
    }
    public findById(subjectId: number): Observable<Subjects> {
        return this.http.get<Subjects>(`${this.baseApiUrl}find-by-id/${subjectId}`);
    }

}
