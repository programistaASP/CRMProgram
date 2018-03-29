using CRMAplication.Models;
using System.Net.Mail;

namespace CRMAplication.Interfaces
{
    public interface IEmailService
    {
        MailMessage CreateMailMessage(Car carmodel);
        void SendEmail(MailMessage mailMessage);
    }
}
