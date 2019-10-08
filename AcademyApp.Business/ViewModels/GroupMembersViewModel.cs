using AcademyApp.Business.Enums;

namespace AcademyApp.Business.ViewModels
{
   public class GroupMembersViewModel
    {

        public int Id { get; set; }

        public int AcademyProgramId { get; set; }

        public int GroupId { get; set; }

        public int UserId { get; set; }

        public UserType UserType { get; set; }

        public string FullName { get; set; }

        public bool AddGroupMember { get; set; }

    }
}
