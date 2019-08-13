using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WebApplication2.Model.Student;

namespace WebApplication2.Model
{
    [Table("Mentor")]
    public class Mentor
    {
        [Key]
        public int ID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        public Gender gender { get; set; }
        public string YearsOfService { get; set; }
        public string Specialty { get; set; }
        public string Telephone { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<Staff> Type { get; set; }
    }
    
}
