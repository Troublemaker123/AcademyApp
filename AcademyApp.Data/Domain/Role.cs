using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public ICollection<User> Users { get; set;}
    }
}
