using AcademyApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApp.Business.Interfaces
{
    public interface IMailService
    {
        //Task<bool> CreateConfirmationLink(string callbackurl, User user);
        Task SendEmail(Email email);
        Task SendEmailActivation(Email email, UserActivation activation);
    }
}
