using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.ViewModels
{
    public class GroupMentorsViewModel
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        public int MentorId { get; set; }

        public int MentorTypeId { get; set; }
    }
}
