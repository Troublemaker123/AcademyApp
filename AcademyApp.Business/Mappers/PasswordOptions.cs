using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Mappers
{
    public class PasswordOptions
    {
        public int RequiredLength { get; internal set; }
        public int RequiredUniqueChars { get; internal set; }
        public bool RequireDigit { get; internal set; }
        public bool RequireLowercase { get; internal set; }
        public bool RequireUppercase { get; internal set; }
        public bool RequireNonAlphanumeric { get; internal set; }
    }
}
