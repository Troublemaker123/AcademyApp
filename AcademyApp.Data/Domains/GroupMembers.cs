using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApp.Data.Domains
{
   public class GroupMembers
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Apid")]
        public int ApId { get; set; }

        [Column("GroupId")]
        public int GroupId { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [Required]
        public int UserType { get; set; }

        public bool AddGroupMember { get; set; }

    }
}
