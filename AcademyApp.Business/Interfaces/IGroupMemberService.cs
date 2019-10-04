using AcademyApp.Business.ViewModels;
using System.Collections.Generic;


namespace AcademyApp.Business.Interfaces
{
   public interface IGroupMemberService
    {
        void Create(GroupMembersViewModel groupMember);
        void Delete(int groupMemberId, int academyProgramId);
        IEnumerable<GroupMembersViewModel> GetAll(int academyProgramId);
        GroupMembersViewModel FindById(int apId);
    }
}
