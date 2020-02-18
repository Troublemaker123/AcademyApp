using AcademyApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyApp.Data
{
    public static class DbContextExtensions
    {
       // private readonly IPasswordHasher _passwordHasher;
        public static void SeedData(this Context dbcontext)
        {
            if (dbcontext.Roles.Any() && dbcontext.Users.Any())
                return;

            var roles = new List<Role>() {
                new Role() {
                    Description = "Administrator"
                },
                 new Role() {
                    Description = "Academy Employee"
                },
                  new Role() {
                    Description = "Mentor"
                },
                  new Role() {
                    Description = "Student"
                }
            };

            var roleAdmin = roles.Find(r => r.Description == "Administrator");
            var administrator = new List<User>() {
                new User() {
                    UserName = "admin",
                    Password =  "1000.EFjrUkILJ3Pm8VAF6LjDxA==.Wf9zD4qkge0mEYe3gkh5G9aJ9a0eHZ/u8CeROqC4oko=",//  _passwordHasher.Hash("admin")
                    IsActive = true,
                    Role = roleAdmin,
                    EmailAddress = "noreply@svslearning.org",
                    IsEmailVerified = true,
                    IsPasswordChanged = true
                }
            };

            dbcontext.AddRange(roles);
            dbcontext.AddRange(administrator);
            dbcontext.SaveChanges();
        }
    }
}
