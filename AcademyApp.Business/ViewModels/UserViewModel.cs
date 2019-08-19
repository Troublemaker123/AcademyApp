using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AcademyApp.Business
{
    class UserViewModel
    {
        [Key]
        public int ID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
    }
}
