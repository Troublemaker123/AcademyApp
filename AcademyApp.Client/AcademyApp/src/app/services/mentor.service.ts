import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Mentor } from '../shared/models/mentors';
import { BasicMentor } from '../shared/models/basicMentor';

@Injectable()
export class MentorService {

    public baseApiUrl: string = `${environment.apiUrl}Employee/mentor/`;

    constructor(private http: HttpClient) { }

    public GetAllMentors(academyProgramId: number): Observable<Mentor[]> {
        return this.http.get<Mentor[]>(`${this.baseApiUrl}get-all/`);
    }
    public GetAllBasicMentors(academyProgramId: number): Observable<BasicMentor[]> {
        return this.http.get<BasicMentor[]>(this.baseApiUrl + 'Admin/mentor/getBasicMentors/' + academyProgramId);
    }
    public create(mentors: Mentor): Observable<Mentor> {
        return this.http.post<Mentor>(`${this.baseApiUrl}create`, mentors);
    }
    public delete(mentorId: number, academyProgramId: number): Observable<any> {
        return this.http.delete<any>(`${this.baseApiUrl}delete/${mentorId}`);
    }
    public update(value: any): Observable<object> {
        return this.http.put(`${this.baseApiUrl}update`, value);
    }
    public findById(mentorId: number): Observable<Mentor> {
        return this.http.get<Mentor>(`${this.baseApiUrl}find-by-id/${mentorId}`);
    }

}
