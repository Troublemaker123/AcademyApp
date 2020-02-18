using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string SmtpEmailAddress { get; set; }
        public string SmtpEmailPassword { get; set; }
        public string adminEmail { get; set; }
    }
}
