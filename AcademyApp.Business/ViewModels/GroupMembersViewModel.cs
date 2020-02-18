using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.ViewModels
{
   public class GroupMembersViewModel
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int UserTypeId { get; set; }

        public string UserType { get; set; }

        public string FullName { get; set; }
    }
}
