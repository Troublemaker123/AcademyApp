using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApp.Data.Domains
{
   public class GroupStudents
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("GroupId")]
        public int GroupId { get; set; }
        public Group Group { get; set; }

        [ForeignKey("UID")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public ICollection<GroupSubjects> SubjectMentors { get; set; }

        // public int AddGroupMember { get; set; }

        // public string FullName { get; set; }

    }
}
