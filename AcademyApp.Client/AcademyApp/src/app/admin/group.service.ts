import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Groups } from '../shared/models/groups';


@Injectable()
export class GroupService {

    public baseApiUrl: string = environment.apiUrl;

    constructor(private http: HttpClient) { }

    public GetAllGroups(groupId: number): Observable<Groups[]> {
        return this.http.get<Groups[]>(this.baseApiUrl + 'Admin/group/get-all/' + groupId);
    }
    public create(groupId: Groups): Observable<Groups> {
        return this.http.post<Groups>(this.baseApiUrl + 'Admin/group/create', groupId);
    }
    public delete(groupId: number, academyProgramId: number): Observable<any> {
        return this.http.delete<any>(`${this.baseApiUrl}Admin/group/delete/${groupId}/${academyProgramId}`);
    }
    public update(value: any): Observable<object> {
        return this.http.put(`${this.baseApiUrl}/Admin/group/update`, value);
    }
    public findById(groupId: number): Observable<Groups> {
        return this.http.get<Groups>(`${this.baseApiUrl}/Admin/group/find-by-id/${groupId}`);
    }

}