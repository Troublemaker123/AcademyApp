using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using static AcademyApp.Model.Student;

namespace AcademyApp.Data.Model
{
    [Table("Mentor")]
    public class Mentor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ID { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
     //   public Gender gender { get; set; }
        public int YearsOfService { get; set; }
        public string Specialty { get; set; }
        public int Telephone { get; set; }
      //  public ICollection<Grade> Grades { get; set; }
      //  public ICollection<Staff> Type { get; set; }
    }
    
}
