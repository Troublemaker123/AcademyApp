using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApp.Model
{
    [Table("GradeCategory")]
    public class GradeCategory
    {
        [Key]
        public int ID { get; set; }
        public int Attended { get; set; }
        public string Date { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
