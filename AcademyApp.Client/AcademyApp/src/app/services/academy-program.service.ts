import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { AcademyProgram } from '../shared/models/academyProgram';

@Injectable({
    providedIn: 'root'
  })
export class AcademyProgramService {

    public baseApiUrl: string = `${environment.apiUrl}Employee/academyProgram/`;

    constructor(private http: HttpClient) { }


    public GetAllAcademyPrograms(): Observable<AcademyProgram[]> {
        return this.http.get<AcademyProgram[]>(`${this.baseApiUrl}get-all`);
    }
    public create(academyProgram: AcademyProgram): Observable<AcademyProgram> {       
        return this.http.post<AcademyProgram>(`${this.baseApiUrl}create`, academyProgram);
    }
    public delete(academyProgramId: number): Observable<any> {
        return this.http.delete<any>(`${this.baseApiUrl}delete/${academyProgramId}`);
    }
    public update(academyProgram: AcademyProgram): Observable<object> {
        return this.http.put(`${this.baseApiUrl}update`, academyProgram);
    }
    public findById(academyProgramId: number): Observable<AcademyProgram> {
        return this.http.get<AcademyProgram>(`${this.baseApiUrl}find-by-id/${academyProgramId}`);
    }

}
