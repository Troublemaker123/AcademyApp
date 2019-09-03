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
        return this.http.get<AcademyProgram[]>(this.baseApiUrl + "admin/ap");
    }
    public create(academyProgram : AcademyProgram): Observable<AcademyProgram> {
        return this.http.post<AcademyProgram>(this.baseApiUrl + 'admin/ap', academyProgram);

    }
    public delete(apId: number): Observable<any> {
        return this.http.delete(`${this.baseApiUrl}/admin/ap/${apId}`, { responseType: 'text' });
    }
    public update(value: any): Observable<object> {
        return this.http.put(`${this.baseApiUrl}/admin/ap`, value);
    }
    public findById(apId:number):Observable<AcademyProgram>{
        return this.http.get<AcademyProgram>(`${this.baseApiUrl}/admin/ap/${apId}`);   
    }

}