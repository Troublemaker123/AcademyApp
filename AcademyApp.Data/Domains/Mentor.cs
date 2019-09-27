using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApp.Data.Model
{
    [Table("Mentor")]
    public class Mentor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("apId")]
        public int ApId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        //   public Gender gender { get; set; }

        [Required]
        public string YearsOfService { get; set; }

        [Required]
        [StringLength(255)]
        public string Specialty { get; set; }

        [Required]
        [StringLength(255)]
        public string Telephone { get; set; }

    }
    
}
