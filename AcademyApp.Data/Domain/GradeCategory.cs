using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyApp.Model
{
    [Table("GradeCategory")]
    public class GradeCategory
    {
        [Key]
        public int ID { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
