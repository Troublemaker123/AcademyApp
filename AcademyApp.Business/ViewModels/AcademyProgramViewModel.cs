using System;
using System.ComponentModel.DataAnnotations;

namespace AcademyApp.Business.ViewModels
{
    public class AcademyProgramViewModel
    {
        [Key]
        public int ID { get; set; }

        public string CreatedBy { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsCurrent { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
