using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Model
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string SubjectDescription{ get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
