using AcademyApp.Data.Model;
using AcademyApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcademyApp.Business.ViewModel
{

  public  class GroupViewModel
    {
   
        public int ID { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<AcademyProgram> Mentors { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}
