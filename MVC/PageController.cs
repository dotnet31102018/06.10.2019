using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VeryEmail.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult ConfirmEmail()
        {
            ViewBag.Title = "Confirm Your Email";


            // Option 1 - return view -- razore page
            //return View("ConfirmEmail");

            // Option 2 - write your own html code using string
            //return Content("Hello world");

            // Option 3 - redirect the user
            //return Redirect("https://www.ynet.co.il/home/0,7340,L-8,00.html");

            // Option 4 - return HTML page from the project
            // return new FilePathResult("~/Views/Page/Error.html", "text/html");


            var q = Request.QueryString;
            Debug.WriteLine(id);

	    // choose between option 1-4
        }
    }
}