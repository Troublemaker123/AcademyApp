using AcademyApp.Business.Helpers;
using AcademyApp.Business.Interfaces;
using AcademyApp.Business.ViewModel;
using AcademyApp.Data;
using AcademyApp.Data.Domains;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AcademyApp.Business.Implementation
{
    public class MailService : IMailService
    {

        private readonly CallBackUrls _urls;
        private readonly AppSettings _settings;
        private readonly IRepository<Email> _emailRepository;
        const string mailGreeting = "<p>Sincerely,<br>Learning Academy Team</br></p>";
        public MailService(IOptions<CallBackUrls> urls, IOptions<AppSettings> settings, IRepository<Email> emailRepository)
        {
            _urls = urls.Value;
            _settings = settings.Value;
            _emailRepository = emailRepository;
        }

        public async Task SendEmail(Email email)
        {
            try
            {
                //instantiate a new MimeMessage
                var message = new MimeMessage();
                //Setting the To e-mail address
                message.To.Add(new MailboxAddress("E-mail Recipient", email.ToMail));
                //Setting the From e-mail address
                message.From.Add(new MailboxAddress("Learning Academy Program", "noreply@svslearning.org"));
                //E-mail subject 
                message.Subject = email.Subject;
                //E-mail message body
                message.Body = new TextPart(TextFormat.Html)
                {
                    Text = email.Message + mailGreeting
                };


                // Credentials
                var credentials = new NetworkCredential(_settings.SmtpEmailAddress, _settings.SmtpEmailPassword);

                //Configure the e-mail
                using (var emailClient = new SmtpClient())
                {
                   await emailClient.ConnectAsync("smtp.gmail.com", 587, false);
                   await emailClient.AuthenticateAsync(credentials.UserName, credentials.Password);
                   await emailClient.SendAsync(message);
                   await emailClient.DisconnectAsync(true);
                }
            }
            catch (Exception)
            {

                return;
            }
        }

        public async Task SendEmailActivation(Email email, UserActivation activation)
        {
            try
            {
                string callBackUrl="";
                int linkType = activation.ActivationType;
                switch (linkType)
                {
                    case 1:
                        callBackUrl = _urls.confirmUrl; // Confirm, then continue
                        break;
                    case 2:
                        callBackUrl = _urls.resetUrl;   // Go to Forget Password page
                        break;
                   default:
                        callBackUrl = _urls.loginUrl;   // go to Login page
                        break;
                }
           
               
                var href = $"{callBackUrl}/{activation.ActivationCode}";
                var linkToClick = String.Format("<br>Please follow this <a href=\"{0}\"> link</a> to continue", href);
 
                //var linkToClick = $"<br>Please follow this link {href}";

                //instantiate a new MimeMessage
                var message = new MimeMessage();
                //Setting the To e-mail address
                message.To.Add(new MailboxAddress("E-mail Recipient", email.ToMail));
                //Setting the From e-mail address
                message.From.Add(new MailboxAddress("Learning Academy Program", "noreply@svslearning.org"));
                //E-mail subject 
                message.Subject = email.Subject;
                //E-mail message body
                message.Body = new TextPart(TextFormat.Html)
                {
                    Text = email.Message + linkToClick + mailGreeting
                };

                // Credentials
                var credentials = new NetworkCredential(_settings.SmtpEmailAddress, _settings.SmtpEmailPassword);

                //Configure the e-mail
                using (var emailClient = new SmtpClient())
                {
                   await emailClient.ConnectAsync("smtp.gmail.com", 587, false);
                   await emailClient.AuthenticateAsync(credentials.UserName, credentials.Password);
                   await emailClient.SendAsync(message);                 
                   await emailClient.DisconnectAsync(true);
                }
            }
            catch (System.Exception ex)
            { 
                return;
            }
        }
    }
}
