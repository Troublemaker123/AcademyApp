using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    [Table("Grade")]
    public class Grade
    {
        [Key]
        public int GradeID { get; set; }
        public string GradeName { get; set; }


    }
}
