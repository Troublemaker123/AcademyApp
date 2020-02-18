using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApp.Data.Domains
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description{ get; set; }

        public int AcademyId { get; set; }

        [ForeignKey("AcademyId")]
        public Academy Academy { get; set; }
        public ICollection<GroupSubjects> GroupSubjects { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
