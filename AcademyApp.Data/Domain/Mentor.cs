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
        public int MentorID { get; set; }
        [Required, MaxLength(50)]
        public string MentorName { get; set; }
        [Required, MaxLength(50)]
        public string MentorLastName { get; set; }
        [Required, MaxLength(50)]
        public string MentorEmail { get; set; }
        public Gender MentorGender { get; set; }
        public string MentorYearsOfService { get; set; }
        public string MentorSpecialty { get; set; }
        public string MentorTelephone { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<Staff> StaffType { get; set; }
    }
    
}
