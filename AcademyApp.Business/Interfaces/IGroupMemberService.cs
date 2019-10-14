using AcademyApp.Business.ViewModels;
using System.Collections.Generic;


namespace AcademyApp.Business.Interfaces
{
   public interface IGroupMemberService
    {
        void Create(List<GroupMembersViewModel> members);
        void Delete(int groupMemberId, int academyProgramId);
        IEnumerable<GroupMembersViewModel> GetAll(int groupId, int academyProgramId);
        GroupMembersViewModel FindById(int apId);
        IEnumerable<GroupMembersViewModel> GetMentorsAndStudents(int groupId, int academyProgramId);
    }
}
