using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;



namespace AcademyApp.Data.Model
{
    [Table("AcademyProgram")]
    public class AcademyProgram
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsCurrent { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }
 
    }
   
}
