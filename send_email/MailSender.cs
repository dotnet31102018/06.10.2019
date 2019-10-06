using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using VeryEmail.Models;

namespace VeryEmail.Controllers
{
    public static class MailSender
    {
        public static void SendEmail(UserData address, Guid g)
        {
            Execute(address, g).Wait();
        }

        static async Task Execute(UserData address, Guid g)
        {
            var apiKey = "<Enter you token here>";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@example.com", "Example User");
            var subject = "Hello " + address.Name + " !";
            var to = new EmailAddress(address.Email, "Example User");
            var plainTextContent = "Please confirm your email";
            var htmlContent = "Click here to confirm your email<br>http://localhost:49799/Page/ConfirmEmail?email=" + address.Email +"&guid=" + g.ToString();
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
