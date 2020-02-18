using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApp.Data.Domains
{
    public class Group
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("APID")]
        public int AcademyProgramId { get; set; }
        public AcademyProgram AcademyProgram { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<GroupStudents> GroupStudents { get; set; }
        public ICollection<GroupMentors> GroupMentors { get; set; }

    }
}
