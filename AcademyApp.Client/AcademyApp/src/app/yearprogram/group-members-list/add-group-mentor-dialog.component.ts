import { Component, OnInit, Inject } from '@angular/core';
import { Groups } from 'src/app/shared/models/groups';
import { GroupList } from 'src/app/shared/models/groupList';
import { Mentor } from 'src/app/shared/models/mentors';
import { GroupService } from '../../services/group.service';
import { GroupMemberService } from '../../services/group-member.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { FormControl } from '@angular/forms';
import { AcademyProgramStateService } from '../../academymgmt/academy-program/academy-program-state.service';
import { SnackbarService } from 'src/app/services/snackbar.service';

@Component({
  selector: 'app-add-group-mentor-dialog',
  templateUrl: './add-group-mentor-dialog.component.html'
})
export class AddGroupMentorDialogComponent implements OnInit {
  title: string;
  groups: Groups[] = [];
  memberGroups: Groups[] = [];
  filteredGroups: Groups[] = [];
  academyProgramId: number;
  mentor: Mentor;
  mentorMember: GroupList = new GroupList();
  
  constructor(private _groupService: GroupService,
    private _groupMemberService: GroupMemberService,
    private academyProgramStateService: AcademyProgramStateService,
    @Inject(MAT_DIALOG_DATA) private data: any,
    private dialogRef: MatDialogRef<AddGroupMentorDialogComponent>,
    private _snackBarService: SnackbarService) {
       if(data)
       {
        this.mentor = this.data.mentor;
       }
     }

     ngOnInit() {
      this.academyProgramId = this.academyProgramStateService.getAcademyProgramId();
      this.getGroups();   
  
      if(this.mentor)
      {
        this.title = 'Add new group member';
        this.mentorMember.memberId = this.mentor.id;
        this.mentorMember.userTypeId = 1;
      }
      let memberId = this.mentorMember.memberId;
      let userTypeId = this.mentorMember.userTypeId;
      this.getGroupsByMember(memberId, userTypeId);   
  
    }
  
    public onSubmit(form: FormControl) {
      if (!form.valid) {
        return;
      }
        this._groupMemberService.create(this.mentorMember, this.mentorMember.groupId).subscribe(result => {
          this.dialogRef.close('ok');
          if(form.dirty)
          this._snackBarService.memberAdded();
        });

       
    }
  
    public onCancel() {
      this.dialogRef.close('cancel');
    }
  
    private getGroups()
    {
      this._groupService.GetAllGroups(this.academyProgramId)
              .subscribe(result => {
                  this.groups = result;
                  this.filteredGroups = this.groups;
              });
    }
  
    private getGroupsByMember(memberId: number, userTypeId: number)
    {
       this._groupMemberService.GetGroupsByMember(memberId, userTypeId)
       .subscribe(result =>
       {
        this.memberGroups = result;    
         if(this.memberGroups != null && this.memberGroups.length > 0)
         {
            let mGroups = this.memberGroups;
            let aGroups = this.groups;
            this.getAvailableGroups(mGroups, aGroups);
         }
       });
    }
  
    private getAvailableGroups(memberGroups: Groups[], allGroups: Groups[])
    {
      let result = allGroups.filter(x => !memberGroups.find(z => z.id === x.id));
      this.filteredGroups = result;
    }  

}
