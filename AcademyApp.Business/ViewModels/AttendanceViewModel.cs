using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AcademyApp.Business.ViewModel
{
   public class AttendanceViewModel
    {

        public int ID { get; set; }
        public int Attended { get; set; }

        public string Date { get; set; }

    }
}
