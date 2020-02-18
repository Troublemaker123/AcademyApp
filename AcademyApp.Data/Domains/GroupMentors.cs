using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AcademyApp.Data.Domains
{
    public class GroupMentors
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("GroupId")]
        public int GroupId { get; set; }
        public Group Group { get; set; }

        [ForeignKey("MentorId")]
        public int MentorId { get; set; }
        public Mentor Mentor { get; set; }
        public int MentorTypeId { get; set; }
    }
}
