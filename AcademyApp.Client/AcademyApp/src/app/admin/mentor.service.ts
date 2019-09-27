import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Mentor } from '../shared/models/mentors';

@Injectable()
export class MentorService{

    public baseApiUrl: string = environment.apiUrl;

    constructor(private http: HttpClient) { }
   

    public GetAllMentors(academyProgramId : number): Observable<Mentor[]> {
        return this.http.get<Mentor[]>(this.baseApiUrl + "mentor/get-all/" + academyProgramId);
    }
    public create(mentors : Mentor): Observable<Mentor> {
        return this.http.post<Mentor>(this.baseApiUrl + 'mentor/create', mentors);
    }
    public delete(mentorId: number): Observable<any> {
        return this.http.delete<Mentor>(`${this.baseApiUrl}mentor/delete/${mentorId}`);
    }
    public update(value: any): Observable<object> {
        return this.http.put(`${this.baseApiUrl}/mentor/update`, value);
    }
    public findById(mentorId:number):Observable<Mentor>{
        return this.http.get<Mentor>(`${this.baseApiUrl}/mentor/find-by-id/${mentorId}`);   
    }


}