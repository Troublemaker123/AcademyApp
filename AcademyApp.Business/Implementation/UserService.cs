using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.Mappers;
using AcademyApp.Business.ViewModel;
using AcademyApp.Business.Helpers;
using AcademyApp.Data;
using AcademyApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Policy;
using AcademyApp.Business.Enums;
using AcademyApp.Business.ViewModels;
using DinkToPdf.Contracts;
using System.IO;

namespace AcademyApp.Business.Implementation
{
    public class UserService : IUserService
    {

        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Mentor> _mentorRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IRepository<Email> _emailRepository;
        private readonly IMailService _mailService;
        private readonly IRepository<UserActivation> _userActivationRepository;
        private readonly IConverter _pdfConverter;

        private const string ROLE_STUDENT = "Student";
        private const string ROLE_MENTOR = "Mentor";

        private readonly AppSettings _appSettings;
        private List<User> _users = new List<User>();

        public UserService(IRepository<User> userRepository, IRepository<Role> roleRepository,
            IRepository<Student> studentRepository, IRepository<Mentor> mentorrepository,
            IOptions<AppSettings> appSettings, IPasswordHasher passwordHasher, 
            IRepository<Email> emailRepository, IMailService mailService,
            IRepository<UserActivation> userActivationRepository, IConverter pdfConverter)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _studentRepository = studentRepository;
            _mentorRepository = mentorrepository;
            _appSettings = appSettings.Value;
            _passwordHasher = passwordHasher;
            _emailRepository = emailRepository;
            _mailService = mailService;
            _userActivationRepository = userActivationRepository;
            _pdfConverter = pdfConverter;
        }
        public void Create(UserViewModel model)
        {
            // If fluent validator didn't catch existing username, add increment number
            if (_userRepository.GetAll().Where(u => u.UserName.ToLower() == model.UserName.ToLower()).Any())
            {
                // UserName already exists, add increment number
                var existing = _userRepository.GetAll().Where(u => u.UserName.ToLower() == model.UserName.ToLower() && u.UserName.Count(ch => ch == '.') > 1).Select(u => Convert.ToInt32(u.UserName.Split('.')[2])).ToList();
                if (existing.Count > 0)
                {
                    // there is more than one firstname.lastname as UserName in db, add number increment fname.lname.(MAX + 1)
                    model.UserName += $".{existing.Max() + 1}";
                }
                else
                {   // set username = fname.lname.1
                    model.UserName += ".1";
                }
            }

            var domain = model.ToDomain();
            var pass = GenerateRandomPassword();
            domain.Password = _passwordHasher.Hash(pass);
            domain.Role = _roleRepository.FindById(model.RoleId);
            _userRepository.Create(domain);

            /*
             print username & generated password {...}
             */
            // Create activation link for User
            var userActivation = new UserActivation()
            {
                UserId = domain.ID,
                ActivationCode = Guid.NewGuid(),
                ActivationType = (int)ActivationLinkType.Register
            };
            _userActivationRepository.Create(userActivation);
    
            string htmlString = $@"<html>
                      <body>
                      <p>Dear { domain.UserName },</p>
                      <p>Thank you for joining our Learning Academy Program! <br> 
                               Your credenitals for login are:<br> username: { domain.UserName } <br> password: {pass} </p>
                      </body>
                      </html>";         

            var emailInfo = new Email() { 
                Subject = "Login Credentials",
                Message = htmlString,
                UserId = domain.ID,
                ToMail = domain.EmailAddress
            };

            // Save raw Email with user credentials in DB, so it can be also printed later
            _emailRepository.Create(emailInfo);
            
            // Now, send confrimation link on user's Email address
            _mailService.SendEmailActivation(emailInfo, userActivation);

            // If Role is Student or Mentor, insert record into their tables
            if (domain.Role.Description == ROLE_STUDENT)
            {
                // Create Student Profile
                var fullname = model.UserName.Split('.');
                var student = new Student()
                {
                    FirstName = fullname[0].FirstCharToUpper(),
                    LastName = fullname[1].FirstCharToUpper(),
                    EmailAdress = domain.EmailAddress,
                    UserId = domain.ID
                };
                _studentRepository.Create(student);
            }
             if (domain.Role.Description == ROLE_MENTOR)
            {
                // Create Mentor Profile
                var fullname = model.UserName.Split('.');
                var mentor = new Mentor()
                {
                    FirstName = fullname[0].FirstCharToUpper(),
                    LastName = fullname[1].FirstCharToUpper(),
                    Email = domain.EmailAddress,
                    UserId = domain.ID
                };
                _mentorRepository.Create(mentor);
            }
            
        }

        public void Delete(int userId)
        {
            var user = _userRepository.FindById(userId);
            if (user == null)
                throw new Exception("User not found");

            user.Emails = _emailRepository.GetAll().Where(e => e.UserId == userId).ToList();
            user.UserActivations = _userActivationRepository.GetAll().Where(ua => ua.UserId == userId).ToList();

            _userRepository.Delete(user);
        }

        public UserViewModel FindById(int userId)
        {
            var user = _userRepository.FindById(userId);
            if (user == null)
                throw new ApplicationException("User not found.");
            user.Emails = _emailRepository.GetAll().Where(e => e.UserId == userId).ToList();
            user.Role = _roleRepository.FindById(user.RoleId);
            return user.ToModel();
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            var uList = _userRepository.GetAll().ToList();
            var resultList = uList.Select(
                    model =>
                    {
                        model.Role = _roleRepository.FindById(model.RoleId);
                        return model.ToModel();
                    }
                );
            return resultList;
        }

        public void Update(UserViewModel model)
        {
            var user = _userRepository.FindById(model.ID);
            if (user == null)
                throw new Exception();

            // Check if updated Username is already existing!

            user.UserName = model.UserName;
            user.IsActive = model.IsActive;
            user.EmailAddress = model.EmailAdress;
            user.RoleId = model.RoleId;
            user.Role = _roleRepository.FindById(model.RoleId);

            _userRepository.Update(user);
        }

        /// <summary>
        /// Generates a Random Password
        /// respecting the given strength requirements.
        /// </summary>
        /// <param name="opts">A valid PasswordOptions object
        /// containing the password strength requirements.</param>
        /// <returns>A random password</returns>
        public static string GenerateRandomPassword(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 2,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = false,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
                     "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
                     "abcdefghijkmnopqrstuvwxyz",    // lowercase
                     "0123456789",                   // digits
                     "!@$?_-"                        // non-alphanumeric
                 };
            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }

        public UserViewModel Login(string username, string password)
        {
            _users = GetActiveUsers().ToList();
            
            var user = _users.SingleOrDefault(x => x.UserName == username && _passwordHasher.Check( x.Password, password).Verified);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.ID.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Role = _roleRepository.FindById(user.RoleId);
      
            return user.ToModel().WithoutPassword();
        }

        public IEnumerable<User> GetActiveUsers()
        {
            var _users = _userRepository.GetAll().Where(x => x.IsActive == true);
            return _users;//.WithoutPasswords();
        }

        public bool IsUserNameUnique(UserViewModel user, string username)
        {
            var existingUser = _userRepository.GetAll().Where(x => x.ID != user.ID && x.UserName.ToLower() == username.ToLower()).ToList();
            if (existingUser == null || existingUser.Count == 0)
                return true;

            return false;
        }

        public User Authenticate(Guid userToken)
        {
            var activation = CheckTokenAuth(userToken, (int)ActivationLinkType.Register);

            // return null if record not found
            if (activation == null)
                return null;

            // check if User is existing
            var user = _userRepository.FindById(activation.UserId);
            if (user == null)
                return null;

            // delete activaion in UserActivations, and update IsEmailVerified in User. return user
            VerifyUserEmail(user);
            _userActivationRepository.Delete(activation);
            return user;
        }

        public UserActivation CheckTokenAuth(Guid userToken, int type)
        {
            var activation = _userActivationRepository.GetAll()
                .Where(ua => ua.ActivationCode == userToken && ua.ActivationType == type && DateTime.Now.Subtract(ua.CreatedOn).TotalMinutes <= 10)
                .SingleOrDefault();

            // return null if record not found
            if (activation == null)
                return null;

            return activation;
        }

        public void VerifyUserEmail(User user)
        {
            user.IsEmailVerified = true;
            _userRepository.Update(user);
        }

        public UserViewModel FindUserByUsername(string username)
        {
            // check if User is existing
            var user = _userRepository.GetAll().Where(u => u.IsActive && u.UserName == username).SingleOrDefault();
            if (user == null)
                return null;
            user.Role = _roleRepository.FindById(user.RoleId);
            return user.ToModel();
        }

        public void SendResetLinkToEmail(UserViewModel user)
        {
            // Create activation link for User
            var userActivation = new UserActivation()
            {
                UserId = user.ID,
                ActivationCode = Guid.NewGuid(),
                ActivationType = (int)ActivationLinkType.ResetPassword    // Forgotten password
            };
            _userActivationRepository.Create(userActivation);

            //Send in Email message
            string htmlString = $@"<html>
                      <body>
                      <p>Dear { user.UserName },</p>
                      <p>You've forgotten your password </p>
                      </body>
                      </html>";

            var emailInfo = new Email()
            {
                Subject = "Forgotten Password",
                Message = htmlString,
                UserId = user.ID,
                ToMail = user.EmailAdress
            };
            _mailService.SendEmailActivation(emailInfo, userActivation);
        }

        public void SendChangedPassEmail(UserViewModel user)
        {
            string htmlString = $@"<html>
                      <body>
                      <p>Dear { user.UserName },</p>
                      <p>You've successfully changed your password!<br> </p>
                      </body>
                      </html>";

            var email = new Email()
            {
                Subject = "Changed Password",
                Message = htmlString,
                UserId = user.ID,
                ToMail = user.EmailAdress
            };
            // Don't save to Emails, send directly notification Email to the User
            _mailService.SendEmail(email);
        }

        public UserViewModel ForgetPassword(Guid userToken, string newPassword)
        {
            var activation = CheckTokenAuth(userToken, (int)ActivationLinkType.ResetPassword);

            // return null if record not found
            if (activation == null)
                return null;

            // check if User is existing
            var user = _userRepository.FindById(activation.UserId);
            if (user == null)
                return null;

            _userActivationRepository.Delete(activation);
            // Change Password
            user.Password = _passwordHasher.Hash(newPassword);
            user.PasswordChangedDate = DateTime.Now;
            user.Role = _roleRepository.FindById(user.RoleId);
            _userRepository.Update(user);

            
            return user.ToModel();
        }

        public UserViewModel ChangePassword(ChangePasswordViewModel model)
        {
            // check Password
            var user = _userRepository.FindById(model.UserId);
            if (!_passwordHasher.Check(user.Password, model.OldPassword).Verified)
                return null; // Current Password doesn't match
            // If it is first login
            if (!user.IsPasswordChanged)
                user.IsPasswordChanged = true;
            // Change Password
            user.Password = _passwordHasher.Hash(model.NewPassword);
            user.PasswordChangedDate = DateTime.Now;
            user.Role = _roleRepository.FindById(user.RoleId);
            _userRepository.Update(user);
            return user.ToModel();
        }

        public void ReSendLoginCredentials(int userId)
        {
            var user = _userRepository.FindById(userId);

            if (user.IsActive && !user.IsEmailVerified)
            {
                // Generate New Password
                var pass = GenerateRandomPassword();
                user.Password = _passwordHasher.Hash(pass);
                user.PasswordChangedDate = DateTime.Now;
                _userRepository.Update(user);

                // Create activation link for User
                var userActivation = new UserActivation()
                {
                    UserId = user.ID,
                    ActivationCode = Guid.NewGuid(),
                    ActivationType = (int)ActivationLinkType.Register
                };
                _userActivationRepository.Create(userActivation);

                //Create New Email
                string htmlString = $@"<html>
                      <body>
                      <p>Dear { user.UserName },</p>
                      <p>Thank you for joining our Learning Academy Program! <br> 
                               Your credenitals for login are:<br> username: { user.UserName } <br> password: {pass} </p>
                      </body>
                      </html>";

                var emailInfo = new Email()
                {
                    Subject = "Login Credentials",
                    Message = htmlString,
                    UserId = user.ID,
                    ToMail = user.EmailAddress
                };

                // Save raw Email with user credentials in DB, so it can be also printed later
                _emailRepository.Create(emailInfo);

                // Now, send confrimation link on user's Email address
                _mailService.SendEmailActivation(emailInfo, userActivation);
            }
        }

        public void PrintLoginCredentials(int userId)
        {
            var user = _userRepository.FindById(userId);
            if (user.IsActive)
            {
                //find last Email with Login credentials
                var email = _emailRepository.GetAll().Where(em => em.UserId == userId).OrderBy(c => c.CreatedOn).FirstOrDefault();
                if (email != null)
                {
                    var pdf = email.Message.CreateDinkToPdf();
                    var pdfFile =  _pdfConverter.Convert(pdf);
                    if (pdf != null)
                        pdf.SendToPrinter();
                }
                   
            }
        }
    }
}
