using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AcademyApp.Data.Domains
{
    //[Table("Attendance")]
    public class Attendance
    {
        [Key]
        public int ID { get; set; }
        //public int Attended { get; set; }
        ////[DataType(DataType.Date)]
        ////[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime Date { get; set; }


    }
}
