using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AcademyApp.Data.Domains
{
    public class Email
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ToMail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsSent { get; set; } = false;
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

    }
}
