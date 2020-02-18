using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApp.Data.Domains
{
   public class GroupSubjects
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int ID { get; set; }

        //[ForeignKey("SubjectId")]
        public int SubjectId { get; set; }
       // public Subject Subject { get; set; }

       // [ForeignKey("GroupId")]
        public int GroupId { get; set; }
      //  public Group Group { get; set; }

    }
}
