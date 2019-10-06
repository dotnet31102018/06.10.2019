using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using VeryEmail.Models;

namespace VeryEmail.Controllers
{
    public class RegisterController : ApiController
    {
        public static Dictionary<string, string> userInfo = new Dictionary<string, string>();
        public void Post([FromBody]UserData userData)
        {
            Guid g = Guid.NewGuid();
            userInfo[userData.Email] = g.ToString();
            MailSender.SendEmail(userData, g);
        }
    }
}
