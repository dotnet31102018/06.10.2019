            if (Session["number"] == null)
                Session["number"] = 1;
            else
            {
                Session["number"] = Convert.ToInt32(Session["number"]) + 1;
            }


            if (HttpContext.Application["number"] == null)
                HttpContext.Application["number"]  = 1;
            else
            {
                HttpContext.Application["number"] = Convert.ToInt32(HttpContext.Application["number"]) + 1;
            }

    

            //return View("ConfirmEmail"); // using Razor page
            return Content("<html><p><h1 style=\"color:red\">Hello World!</h1>"
                + DateTime.Now + "</p>" + Session["number"] + " <br>" + 
                HttpContext.Application["number"] + "</ html>"); // just write text as the result
