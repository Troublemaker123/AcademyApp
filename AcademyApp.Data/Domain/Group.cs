using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApp.Model
{
    [Table("Group")]
    public class Group
    {
        [Key]
        public int ID { get; set; }
       // public ICollection<Student> Students { get; set; }
      //  public ICollection<Mentor> Mentors { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}
