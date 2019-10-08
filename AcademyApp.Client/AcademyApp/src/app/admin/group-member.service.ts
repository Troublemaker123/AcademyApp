import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GroupMembers } from '../shared/models/groupMembers';


@Injectable()
export class GroupMemberService {

    public baseApiUrl: string = environment.apiUrl;

    constructor(private http: HttpClient) { }

    public GetAllGroupMembers(groupMemberId: number): Observable<GroupMembers[]> {
        return this.http.get<GroupMembers[]>(this.baseApiUrl + 'Admin/groupMember/get-all/' + groupMemberId);
    }
    public GetAllStudentsandMentors(studentsAndMentorsId: number): Observable<GroupMembers[]> {
        return this.http.get<GroupMembers[]>(this.baseApiUrl + 'Admin/groupMember/getMentorsAndStudents/' + studentsAndMentorsId);
    }
    public create(groupMemberId: GroupMembers): Observable<GroupMembers> {
        return this.http.post<GroupMembers>(this.baseApiUrl + 'Admin/groupMember/create', groupMemberId);
    }
    public delete(groupMemberId: number, academyProgramId: number): Observable<any> {
        return this.http.delete<any>(`${this.baseApiUrl}Admin/groupMember/delete/${groupMemberId}/${academyProgramId}`);
    }
    public update(value: any): Observable<object> {
        return this.http.put(`${this.baseApiUrl}/Admin/groupMember/update`, value);
    }
    public findById(groupMemberId: number): Observable<GroupMembers> {
        return this.http.get<GroupMembers>(`${this.baseApiUrl}/Admin/groupMember/find-by-id/${groupMemberId}`);
    }

}
