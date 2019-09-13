import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Mentor } from '../shared/models/mentors';

@Injectable()
export class MentorService{

    public baseApiUrl: string = environment.apiUrl;

    constructor(private http: HttpClient) { }
   

    public GetAllMentors(): Observable<Mentor[]> {
        return this.http.get<Mentor[]>(this.baseApiUrl + "mentor/me");
    }
    public create(mentors : Mentor): Observable<Mentor> {
        return this.http.post<Mentor>(this.baseApiUrl + 'mentor/me', mentors);
    }
    public delete(apId: number): Observable<any> {
        return this.http.delete<Mentor>(`${this.baseApiUrl}mentor/me/${apId}`);
    }
    public update(value: any): Observable<object> {
        return this.http.put(`${this.baseApiUrl}/mentor/me`, value);
    }
    public findById(apId:number):Observable<Mentor>{
        return this.http.get<Mentor>(`${this.baseApiUrl}/mentor/me/${apId}`);   
    }


}