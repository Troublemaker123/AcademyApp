using AcademyApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AcademyApp.Business.ViewModel
{
    class ProgramViewModel
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}
