using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
 
namespace WebApiWithPages.Controllers
{
    public class PageController : Controller
    {
 
        static void Execute(string myGuid)
        {
            var apiKey = "<Your-Api-Code>";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@example.com", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("python240419@gmail.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "click here do verify email:<br>http://localhost:51063/Page/ConfirmEmail?guid=" + myGuid;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg).Result;
        }
 
 
        // GET: Page
        public ActionResult Email()
        {
            //var q = Request.QueryString;
            //var name = q.Get("name");
            //var color = q.Get("color");
 
            string myGuid = Guid.NewGuid().ToString();
            Session["guid"] = myGuid;
 
            Execute(myGuid);
            return Content($"Email sent");
 
            //return View("Email");
        }
 
        public ActionResult ConfirmEmail()
        {
           
            var q = Request.QueryString;
            var guid = q.Get("guid");
            //var color = q.Get("color");
            string guid_home = Session["guid"].ToString();
            if (guid == guid_home)
                return Content($"Email confirmed");
            return Content($"Email NOT confirmed! watch out!!!");
 
            //return View("Email");
        }
 
        public ActionResult PageString()
        {
            return Content("<b>page build with string</b> " + DateTime.Now);
        }
 
        public ActionResult RedirectMe()
        {
            return Redirect("https://www.ynet.co.il/home/0,7340,L-8,00.html");
        }
 
        public ActionResult ShowHTML()
        {
            return new FilePathResult("~/Views/Page/HtmlPage1.html", "text/html");
        }
    }
}