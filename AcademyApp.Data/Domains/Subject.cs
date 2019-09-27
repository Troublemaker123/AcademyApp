using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace AcademyApp.Data.Model
{
    [Table("Subject")]
    public class Subject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int ID { get; set; }
        [Column("ApId")]
        public int ApId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description{ get; set; }

      //  public ICollection<Grade> grades { get; set; }

       // public ICollection<Student> Students { get; set; }

    }
}
