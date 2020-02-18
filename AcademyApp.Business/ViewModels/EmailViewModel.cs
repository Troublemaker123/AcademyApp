using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.ViewModels
{
    public class EmailViewModel
    {
        public int Id { get; set; }
        public string ToMail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsSent { get; set; } = false;
        public int? UserId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
