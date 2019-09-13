using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApp.Data.Model
{
    [Table("Subject")]
    public class Subject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
      //  public ICollection<Grade> grades { get; set; }
       // public ICollection<Student> Students { get; set; }
    }
}
