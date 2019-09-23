using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using static AcademyApp.Model.Student;

namespace AcademyApp.Data.Model
{
    [Table("Mentor")]
    public class Mentor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ID { get; set; }
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
        public int YearsOfService { get; set; }
        [Required]
        [StringLength(255)]
        public string Specialty { get; set; }
        [Required]
        [StringLength(255)]
        public int Telephone { get; set; }

      //  public ICollection<Grade> Grades { get; set; }
      //  public ICollection<Staff> Type { get; set; }
    }
    
}
