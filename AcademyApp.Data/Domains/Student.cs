using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApp.Data.Domains
{
    [Table("Student")]
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("apid")]
        public int ApId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [StringLength(255)]
        public string PlaceOfBirth { get; set; }

        public int? GenderId { get; set; }

        [Required]
        [StringLength(255)]
        public string Mobile { get; set; }

        [Required]
        [StringLength(255)]
        public string Country { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string EmailAdress { get; set; }

        [Required]
        public DateTime GraduationYear { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public DateTime DateOfEnrollment { get; set; }

    } 
      
}
