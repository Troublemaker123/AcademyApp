using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AcademyApp.Data.Domains
{
    public class NonWorkingDay
    {
        public int Id { get; set; }
        public int AcademyProgramId { get; set; }
        [ForeignKey("AcademyProgramId")]
        public AcademyProgram AcademyProgram { get; set; }
        public int EventTypeId { get; set; }
        public DateTime EventDate { get; set; }
    }
}
