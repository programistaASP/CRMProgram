using CRMAplication.Interfaces;
using CRMAplication.Models;
using System.Net;
using System.Net.Mail;

namespace CRMAplication.Service
{
    public class EmailService: IEmailService
    {
        private SmtpClient _smtpClient;
        private const string _login = "witar1@gmail.com";
        private const string _pass = "Heroes840715";

        public EmailService()
        {
            Initialize();
        }
        private void Initialize()
        {
            _smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(_login, _pass)
            };
        }
        public MailMessage CreateMailMessage(Car carmodel)
        {
            return new MailMessage
            {
                Sender = new MailAddress(_login),
                From = new MailAddress(_login),
                To = { _login },
                Subject = $"Unauthorized person added car at {carmodel.DateCreate}",
                Body = "Unauthorized person added car",
                IsBodyHtml = true
            };
        }
        public void SendEmail(MailMessage mailMessage)
        {
            _smtpClient.Send(mailMessage);
        }
    }
}
