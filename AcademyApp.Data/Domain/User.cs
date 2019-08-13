using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required,MaxLength(50)]
        public string UserName { get; set; }
        [Required, MaxLength(50)]
        public string UserPassword { get; set; }

    }
}
