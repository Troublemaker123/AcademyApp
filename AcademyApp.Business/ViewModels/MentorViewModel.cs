using AcademyApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace AcademyApp.Business.ViewModel
{
    public class MentorViewModel
    {

        public int ID { get; set; }

        public int AcademyProgramId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }
  
        public string Email { get; set; }

     //   public Gender Gender { get; set; }

        public string YearsOfService { get; set; }

        public string Specialty { get; set; }

        public string Telephone { get; set; }
 
    }
}
