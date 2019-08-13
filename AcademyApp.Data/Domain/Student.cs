using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Model
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        [Required, MaxLength(50),RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string StudentName { get; set; }
        [Required, MaxLength(50)]
        public string StudentLastName { get; set; }
        [Required, MaxLength(50)]
        public string PlaceOfBirth { get; set; }
        public Gender StudentGender { get; set; }
        public string StudentMobile { get; set; }
        public string StudentCountry { get; set; }
        public string StudentEmailAdress { get; set; }
        public string StudentGraduationYear { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string StudentDateOfBirth { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString  = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StudentDateOfEnrollment { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        //  public ICollection<Attendance> Attendances { get; set; }
        // public ICollection<Attendance> Attendances { get; set; }
        public enum Gender
        {
            Male,
            Female,
            Other
        }

    } 
    

    
}
