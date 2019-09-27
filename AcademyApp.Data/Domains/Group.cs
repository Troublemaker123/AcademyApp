using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApp.Model
{
    [Table("Group")]
    public class Group
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }

    }
}
