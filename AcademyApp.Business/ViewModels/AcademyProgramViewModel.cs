using System;

namespace AcademyApp.Business.ViewModel
{
    public class AcademyProgramViewModel
    {
 
        public int ID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsCurrent { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public int CreatedBy { get; set; }

        public int AcademyId { get; set; }
        public string AcademyName { get; set; }
    }
}
