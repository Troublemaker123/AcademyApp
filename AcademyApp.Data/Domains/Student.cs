using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApp.Data.Model
{
    [Table("Student")]
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ID { get; set; }

        public string Name { get; set; }
    
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PlaceOfBirth { get; set; }
       // public Gender gender { get; set; }
        public int Mobile { get; set; }
        public string Country { get; set; }
        public string EmailAdress { get; set; }
        public DateTime GraduationYear { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfEnrollment { get; set; }
   //     public ICollection<Attendance> Attendances { get; set; }

        public enum Gender
        {
            Male,
            Female,
            Other
        }

    } 
    

    
}
