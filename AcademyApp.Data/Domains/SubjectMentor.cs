using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApp.Data.Domains
{
   public class SubjectMentor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("MentorId")]
        public int MentorId { get; set; }

        [Column("SubjectId")]
        public int SubjectId { get; set; }

        [Column("AcademyProgramId")]
        public int AcademyProgramId { get; set; }

    }
}
