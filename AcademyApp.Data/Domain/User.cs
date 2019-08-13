using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyApp.Model
{
    [Table("User")]
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }

    }
}
