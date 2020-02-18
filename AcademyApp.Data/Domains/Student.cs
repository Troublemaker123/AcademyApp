using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApp.Data.Domains
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string PlaceOfBirth { get; set; }

        public int? GenderId { get; set; }

        [StringLength(255)]
        public string Mobile { get; set; }

        [StringLength(255)]
        public string Country { get; set; }

        [EmailAddress]
        [StringLength(255)]
        public string EmailAdress { get; set; }

        public DateTime? GraduationYear { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateOfEnrollment { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public ICollection<GroupStudents> GroupStudents { get; set; }

        [ForeignKey("AcademyProgramId")]
        public int? AcademyProgramId { get; set; }
        public AcademyProgram AcademyProgram { get; set; }
        public ICollection<Rating> Ratings { get; set; }

    } 
      
}
