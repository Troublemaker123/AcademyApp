import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { AcademyProgram } from '../shared/models/academyProgram';



@Injectable()
export class AdminService {

    public baseApiUrl: string = environment.apiUrl;

    constructor(private http: HttpClient) { }


    public GetAllAcademyPrograms(): Observable<AcademyProgram[]> {
        return this.http.get<AcademyProgram[]>(this.baseApiUrl + 'academyprogram/get-all');
    }
    public create(academyProgram: AcademyProgram): Observable<AcademyProgram> {
        return this.http.post<AcademyProgram>(this.baseApiUrl + 'academyprogram/create', academyProgram);
    }
    public delete(academyProgramId: number): Observable<any> {
        return this.http.delete<any>(`${this.baseApiUrl}academyprogram/delete/${academyProgramId}`);
    }
    public update(value: any): Observable<object> {
        return this.http.put(`${this.baseApiUrl}/academyprogram/update`, value);
    }
    public findById(academyProgramId: number): Observable<AcademyProgram> {
        return this.http.get<AcademyProgram>(`${this.baseApiUrl}/academyprogram/find-by-id/${academyProgramId}`);
    }

}
