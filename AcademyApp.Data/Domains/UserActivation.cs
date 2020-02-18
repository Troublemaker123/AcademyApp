using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AcademyApp.Data.Domains
{
    public class UserActivation
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid ActivationCode { get; set; }
        public int ActivationType { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
