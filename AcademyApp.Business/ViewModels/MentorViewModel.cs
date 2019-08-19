using AcademyApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static AcademyApp.Model.Student;

namespace AcademyApp.Business
{
    public class MentorViewModel
    {
        [Key]
        public int ID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string YearsOfService { get; set; }
        public string Specialty { get; set; }
        public string Telephone { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}
