using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;



namespace AcademyApp.Data.Domains
{
    public class AcademyProgram
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ID { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public bool IsCurrent { get; set; } = false;

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

       
        public int AcademyId { get; set; }

        [ForeignKey("AcademyId")]
        public Academy Academy { get; set; }

    }
   
}
