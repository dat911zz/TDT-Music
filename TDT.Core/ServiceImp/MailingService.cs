using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TDT.Core.IService;
using TDT.Core.Models;

namespace TDT.Core.ServiceImp
{
    public class MailingService : IMailingService<SMail>, IEmailSender
    {
        private string username, password;
        #region SingleTon Patterm        
        private static MailingService instance;
        private readonly ILogger _logger;

        public MailingService(ILogger<MailingService> logger)
        {
            _logger = logger;
        }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        private static readonly string EMAIL_ADDRESS = "noreply.tdt.ad@gmail.com";
        #endregion
        #region Sender
        /// <summary>
        /// Mail Sender
        /// </summary>
        /// <param name="mailObj"></param>
        public void MailSender(SMail mailObj)
        {
            MailMessage mail = new MailMessage();
            SetupMail(ref mail, mailObj);
            SmtpClient smtp = new SmtpClient();
            SetupSmtpClient(ref smtp);
            smtp.Send(mail);
        }
        /// <summary>
        /// Use for mail configuration
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="mailObj"></param>
        public void SetupMail(ref MailMessage mail, SMail mailObj)
        {
            mail.To.Add(mailObj.To);
            mail.From = new MailAddress(EMAIL_ADDRESS);
            mail.Subject = mailObj.Subject;
            mail.Body = mailObj.Body;
            mail.IsBodyHtml = true;
        }
        /// <summary>
        /// Use for setup Smtp Client (Do not change this method!)
        /// </summary>
        /// <param name="smtp"></param>
        public void SetupSmtpClient(ref SmtpClient smtp)
        {
            Username = EMAIL_ADDRESS;
            Password = "ufbibbbzzjuwftuk";//App password
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(username, password);
            smtp.EnableSsl = true;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                MailSender(new SMail("", email, subject, htmlMessage));
                _logger.LogInformation("Mail sended [to: {0} - subject: {1}] ", email, subject);
                return Task.FromResult(1);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Cannot send mail to " + email);
                return Task.FromResult(0);
            }            
        }
        #endregion
    }
}
