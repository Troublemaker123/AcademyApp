using System;

namespace AcademyApp.Business.ViewModel
{
    public class AcademyProgramViewModel
    {
 
        public int Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsCurrent { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
