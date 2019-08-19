using AcademyApp.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace AcademyApp.Business.ViewModel
{
    public class StudentViewModel
    {
        [Key]
        public int ID { get; set; }
        [Required, MaxLength(50), RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, MaxLength(50)]
        public string PlaceOfBirth { get; set; }
        public Gender gender { get; set; }
        public string Mobile { get; set; }
        public string Country { get; set; }
        public string EmailAdress { get; set; }
        public string GraduationYear { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string DateOfBirth { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfEnrollment { get; set; }
        public ICollection<Attendance> Attendance { get; set; }

        public enum Gender
        {
            Male,
            Female,
            Other
        }

    }
}
