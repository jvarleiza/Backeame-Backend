using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Backeame.OwinManagers.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await SendEmailAsync(message);
        }

        // Use NuGet to install SendGrid (Basic C# client lib) 
        private async Task SendEmailAsync(IdentityMessage message)
        {
            using (SmtpClient client = new SmtpClient())
            {
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Host = "smtp.gmail.com";
                client.Port = 587;

                // setup Smtp authentication
                NetworkCredential credentials = new NetworkCredential(
                        ConfigurationManager.AppSettings["backeameMail"],
                        ConfigurationManager.AppSettings["backeamePassword"]);
                client.UseDefaultCredentials = false;
                client.Credentials = credentials;

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(ConfigurationManager.AppSettings["backeameMail"]);
                msg.To.Add(new MailAddress(message.Destination));

                msg.Subject = message.Subject;
                msg.IsBodyHtml = true;
                msg.Body = message.Body;

                try
                {
                    client.Send(msg);
                    await Task.FromResult(0);
                }
                catch (Exception ex)
                {
                    await Task.FromException(ex);
                }
            }
        }
    }
}
