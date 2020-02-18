using System;
using AcademyApp.Business.Enums;

namespace AcademyApp.Business.ViewModel
{
    public class StudentViewModel
    {
   
        public int ID { get; set; }
 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PlaceOfBirth { get; set; }

        public int? GenderId { get; set; }
        public string GenderName { get; set; }

        public string Mobile { get; set; }

        public string Country { get; set; }

        public string EmailAdress { get; set; }

        public DateTime? GraduationYear { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateOfEnrollment { get; set; }
        public int? AcademyProgramId { get; set; }
    }
}
