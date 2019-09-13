using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyApp.Model
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int ID { get; set; }
        public ICollection<User> Users { get; set;}
    }
}
