import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Student } from '../shared/models/student';


@Injectable()
export class StudentService {

    public baseApiUrl: string = environment.apiUrl;

    constructor(private http: HttpClient) { }

    public GetAllStudents(academyProgramId: number): Observable<Student[]> {
        return this.http.get<Student[]>(this.baseApiUrl + 'student/get-all/' + academyProgramId);
    }
    public create(student: Student): Observable<Student> {
        return this.http.post<Student>(this.baseApiUrl + 'student/create', student);
    }
    public delete(studentId: number, academyProgramId: number): Observable<any> {
        return this.http.delete<any>(`${this.baseApiUrl}student/delete/${studentId}/${academyProgramId}`);
    }
    public update(value: any): Observable<object> {
        return this.http.put(`${this.baseApiUrl}/student/update`, value);
    }
    public findById(studentId: number): Observable<Student> {
        return this.http.get<Student>(`${this.baseApiUrl}/student/find-by-id/${studentId}`);
    }

}
