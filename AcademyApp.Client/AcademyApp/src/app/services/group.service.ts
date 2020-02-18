import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Groups } from '../shared/models/groups';


@Injectable()
export class GroupService {

    public baseApiUrl: string = `${environment.apiUrl}Employee/group/`;

    constructor(private http: HttpClient) { }

    public GetAllGroups(apid: number): Observable<Groups[]> {
        return this.http.get<Groups[]>(`${this.baseApiUrl}get-all/${apid}`);
    }
    public create(group: Groups): Observable<Groups> {
        return this.http.post<Groups>(`${this.baseApiUrl}create`, group);
    }
    public delete(groupId: number): Observable<any> {
        return this.http.delete<any>(`${this.baseApiUrl}delete/${groupId}`);
    }
    public update(value: any): Observable<object> {
        return this.http.put(`${this.baseApiUrl}update`, value);
    }
    public findById(groupId: number): Observable<Groups> {
        return this.http.get<Groups>(`${this.baseApiUrl}find-by-id/${groupId}`);
    }

}
