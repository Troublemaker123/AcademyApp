import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Student } from '../shared/models/student';


@Injectable()
export class StudentService{

    public baseApiUrl: string = environment.apiUrl;

    constructor(private http: HttpClient) { }
   

    public GetAllStudents(): Observable<Student[]> {
        return this.http.get<Student[]>(this.baseApiUrl + "student/get-all");
    }
    public create(student : Student): Observable<Student> {
        return this.http.post<Student>(this.baseApiUrl + 'student/create', student);
    }
    public delete(studentId: number): Observable<any> {
        return this.http.delete<Student>(`${this.baseApiUrl}student/delete/${studentId}`);
    }
    public update(value: any): Observable<object> {
        return this.http.put(`${this.baseApiUrl}/student/update`, value);
    }
    public findById(studentId:number):Observable<Student>{
        return this.http.get<Student>(`${this.baseApiUrl}/student/find-by-id/${studentId}`);   
    }


}