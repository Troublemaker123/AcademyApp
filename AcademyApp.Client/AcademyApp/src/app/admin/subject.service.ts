import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Subjects } from '../shared/models/subjects';





@Injectable()
export class SubjectService {
   
    public baseApiUrl: string = environment.apiUrl;

    constructor(private http: HttpClient) { }
   

    public GetAllSubjects(): Observable<Subjects[]> {
        return this.http.get<Subjects[]>(this.baseApiUrl + "subject/sub");
    }
    public create(subject : Subjects): Observable<Subjects> {
        return this.http.post<Subjects>(this.baseApiUrl + 'subject/sub', subject);
    }
    public delete(apId: number): Observable<any> {
        return this.http.delete<Subjects>(`${this.baseApiUrl}subject/sub/${apId}`);
    }
    public update(value: any): Observable<object> {
        return this.http.put(`${this.baseApiUrl}/subject/sub`, value);
    }
    public findById(apId:number):Observable<Subjects>{
        return this.http.get<Subjects>(`${this.baseApiUrl}/subject/sub/${apId}`);   
    }

}