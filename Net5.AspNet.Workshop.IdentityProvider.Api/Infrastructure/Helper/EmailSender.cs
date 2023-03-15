using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Helper
{
    public class EmailSender : IEmailSender
    {
        public const string MAIL_HOST = "localhost";
        public const int MAIL_PORT = 1025;

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress("Administrator", "admin@todo.local"));
            msg.To.Add(new MailboxAddress("", email));
            msg.Subject = subject;
            msg.Body = new TextPart("plain")
            {
                Text = message
            };

            using (var mailClient = new SmtpClient())
            {
                await mailClient.ConnectAsync(MAIL_HOST, MAIL_PORT, SecureSocketOptions.None);
                await mailClient.SendAsync(msg);
                await mailClient.DisconnectAsync(true);
            }
        }
    }
}
