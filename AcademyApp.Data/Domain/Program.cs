using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Model
{
    [Table("Program")]
    public class Program
    {
        [Key]
        public int ProgramID { get; set; }
        public string ProgramName { get; set; }
        public string ProgramDescription { get; set; }
        public ICollection<Subject> Subjects { get; set; }

    }
}
