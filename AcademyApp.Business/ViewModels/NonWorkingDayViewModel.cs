using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.ViewModels
{
    public class NonWorkingDayViewModel
    {
        public int Id { get; set; }
        public int AcademyProgramId { get; set; }
        public int EventTypeId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
    }
}
