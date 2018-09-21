using LogicXPro.Domain.Interfaces.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LogicXPro.Domain.Managers
{
    public class EmailNotification : IEmailNotification
    {
        public async Task SendEmail(string toEmail, string cc, string subject, string body, string SmtpServer, int SmtpPort, string SmtpUserName, string SmtpPassword)
        {
           await Task.Run(() =>
            {
                SmtpClient client = new SmtpClient();
                client.Host = SmtpServer;
                client.Port = SmtpPort;
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(SmtpUserName, SmtpPassword);
                MailAddress fromAddress = new MailAddress(SmtpUserName, "Support Team", System.Text.Encoding.UTF8);
                MailMessage message = new MailMessage();
                message.From = fromAddress;

                foreach (var email in toEmail.Split(';'))
                {
                    message.To.Add(email);
                }

                foreach (var email in cc.Split(';'))
                {
                    message.CC.Add(email);
                }

                message.Body = body;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                message.Subject = subject;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                client.Send(message);
                message.Dispose();
            });
        }
    }
}
