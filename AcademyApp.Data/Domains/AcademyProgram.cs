using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;



namespace AcademyApp.Data.Domains
{
    [Table("AcademyProgram")]
    public class AcademyProgram
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public bool IsCurrent { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        [StringLength(255)]
        public string CreatedBy { get; set; }
       
 
    }
   
}
