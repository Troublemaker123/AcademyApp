using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AcademyApp.Business
{
    class StaffViewModel
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
