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
}