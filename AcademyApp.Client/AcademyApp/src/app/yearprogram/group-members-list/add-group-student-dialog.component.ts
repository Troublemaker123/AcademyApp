import { Component, OnInit, Inject } from '@angular/core';
import { Groups } from 'src/app/shared/models/groups';
import { GroupService } from '../../services/group.service';
import { Student } from 'src/app/shared/models/student';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { GroupList } from 'src/app/shared/models/groupList';
import { FormControl } from '@angular/forms';
import { GroupMemberService } from '../../services/group-member.service';
import { ɵAnimationGroupPlayer } from '@angular/animations';
import { AcademyProgramStateService } from '../../academymgmt/academy-program/academy-program-state.service';
import { SnackbarService } from 'src/app/services/snackbar.service';

@Component({
  selector: 'app-add-group-student-dialog',
  templateUrl: './add-group-student-dialog.component.html'
})
export class AddGroupStudentDialogComponent implements OnInit {

  title: string;
  groups: Groups[] = [];
  memberGroups: Groups[] = [];
  filteredGroups: Groups[] = [];

  student: Student;
  studentMember: GroupList = new GroupList();
  backGroundColor: string;
  academyProgramId: number;

  constructor(private _groupService: GroupService,
    private _groupMemberService: GroupMemberService,
    private academyProgramStateService: AcademyProgramStateService,
    @Inject(MAT_DIALOG_DATA) private data: any,
    private dialogRef: MatDialogRef<AddGroupStudentDialogComponent>,
    private _snackBarService: SnackbarService) {
       if(data)
       {
        this.student = this.data.student;
       }
     }

  ngOnInit() {
    this.academyProgramId = this.academyProgramStateService.getAcademyProgramId();
    this.getGroups();

    if(this.student)
    {
      this.title = 'Add new group member';
      this.studentMember.memberId = this.student.id;
      this.studentMember.userTypeId = 0;
    }
    let memberId = this.studentMember.memberId;
    let userTypeId = this.studentMember.userTypeId;
    this.getGroupsByMember(memberId, userTypeId);   

    let bColor = this.getRandomColor();
    this.backGroundColor = bColor;
  }

  public onSubmit(form: FormControl) {
    if (!form.valid) {
      return;
    }
      this._groupMemberService.create(this.studentMember, this.studentMember.groupId).subscribe(result => {
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
  
  public  getRandomColor() {
    var color = Math.floor(0x1000000 * Math.random()).toString(16);
    return '#' + ('000000' + color).slice(-6);
  }

}
