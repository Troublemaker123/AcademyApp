import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Subjects } from '../shared/models/subjects';


@Injectable()
export class SubjectService {

    public baseApiUrl: string = environment.apiUrl;

    constructor(private http: HttpClient) { }


    public GetAllSubjects(academyProgramId: number): Observable<Subjects[]> {
        return this.http.get<Subjects[]>(this.baseApiUrl + 'subject/get-all/' + academyProgramId);
    }
    public create(subjectId: Subjects): Observable<Subjects> {
        return this.http.post<Subjects>(this.baseApiUrl + 'subject/create', subjectId);
    }
    public delete(subjectId: number, academyProgramId: number): Observable<any> {
        return this.http.delete<any>(`${this.baseApiUrl}subject/delete/${subjectId}/${academyProgramId}`);
    }
    public update(value: any): Observable<object> {
        return this.http.put(`${this.baseApiUrl}/subject/update`, value);
    }
    public findById(subjectId: number): Observable<Subjects> {
        return this.http.get<Subjects>(`${this.baseApiUrl}/subject/find-by-id/${subjectId}`);
    }

}
