import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GroupMembers } from '../shared/models/groupMembers';
import { GroupList } from '../shared/models/groupList';
import { Groups } from '../shared/models/groups';


@Injectable()
export class GroupMemberService {

    public baseApiUrl: string = `${environment.apiUrl}Employee/groupMember/`;

    constructor(private http: HttpClient) { }

    public GetAllGroupMembers(groupId: number): Observable<GroupList[]> {
        return this.http.get<GroupList[]>(`${this.baseApiUrl}get-all/${groupId}`);
    }
    public GetAllStudentsandMentors(groupId: number, academyProgramId: number): Observable<GroupMembers[]> {
        return this.http.get<GroupMembers[]>
        (this.baseApiUrl + 'Admin/groupMember/getMentorsAndStudents/' + groupId + '/' + academyProgramId);
    }
    public GetGroupsByMember(memberId: number, userTypeId: number): Observable<Groups[]> {
        return this.http.get<Groups[]>
        (`${this.baseApiUrl}getGroupsByMember/${memberId}/${userTypeId}`);
    }
    public create(member: GroupList, groupId: number): Observable<GroupList> {
        return this.http.post<GroupList>(`${this.baseApiUrl}create/${groupId}`, member);
    }
    public delete(groupMemberId: number, userTypeId: number): Observable<any> {
        return this.http.delete<any>(`${this.baseApiUrl}delete/${groupMemberId}/${userTypeId}`);
    }
    public update(value: any): Observable<object> {
        return this.http.put(`${this.baseApiUrl}/Admin/groupMember/update`, value);
    }
    public findById(groupMemberId: number): Observable<GroupMembers> {
        return this.http.get<GroupMembers>(`${this.baseApiUrl}/Admin/groupMember/find-by-id/${groupMemberId}`);
    }

}
