using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicXPro.Domain.Interfaces.Utilities
{
   public interface IEmailNotification
    {
        Task SendEmail(string toEmail, string cc, string subject, string body, string SmtpServer, int SmtpPort, string SmtpUserName, string SmtpPassword);
    }
}
