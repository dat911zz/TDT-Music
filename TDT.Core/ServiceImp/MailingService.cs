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
    public class MailingService : IMailingService<SMail>
    {
        private string username, password;
        #region SingleTon Patterm        
        private static MailingService instance;
        private MailingService() { }
        public static MailingService Instance { get => instance ?? new MailingService(); private set => instance = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        private static readonly string MAIL_ADDRESS = "noreply.tdt.ad@gmail.com";
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
            mail.From = new MailAddress(MAIL_ADDRESS);
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
            Username = MAIL_ADDRESS;
            Password = "suebuwfgwmysbrow";//App password
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential(username, password);
            smtp.EnableSsl = true;
        }
        #endregion
    }
}
