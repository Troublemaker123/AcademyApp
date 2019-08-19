using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AcademyApp.Business
{
    class AttendanceViewModel
    {
        [Key]
        public int ID { get; set; }
        public int Attended { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Date { get; set; }

    }
}
