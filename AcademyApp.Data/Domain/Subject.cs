using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Model
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
        public ICollection<Grade> grades { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
