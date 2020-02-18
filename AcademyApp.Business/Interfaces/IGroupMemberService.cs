using AcademyApp.Business.ViewModel;
using AcademyApp.Business.ViewModels;
using System.Collections.Generic;


namespace AcademyApp.Business.Interfaces
{
   public interface IGroupMemberService
    {
        void Create(List<GroupStudentsViewModel> members);
        void Delete(int groupMemberId, int userTypeId);
        IEnumerable<GroupMembersViewModel> GetAll(int groupId);
        GroupStudentsViewModel FindById(int apId);
        IEnumerable<GroupStudentsViewModel> GetMentorsAndStudents(int groupId, int academyProgramId);
        void Create(GroupMembersViewModel model, int groupId);

        IEnumerable<GroupViewModel> GetGroupsByMember(int memberId, int userTypeId);
    }
}
