using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace PersonalWebsite.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
             var fromMail = "Salma@gmail.com";
            var fromPassword = "123456";

            var message = new MailMessage();
            message.From=new MailAddress(fromMail);
            message.Subject=subject;
            message.Body=$"<html><body>htmlMessage</html></body>";
            message.To.Add(email);
            message.IsBodyHtml = true;
            var stmpClient = new SmtpClient("stmp-mail.outlook.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail,fromPassword),
                EnableSsl=true,
            };
            stmpClient.Send(message);


        }
    }
}
