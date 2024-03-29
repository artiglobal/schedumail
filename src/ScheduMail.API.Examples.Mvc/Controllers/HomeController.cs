﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScheduMail.API.Examples.Mvc.Controllers {
  [HandleError]
  public class HomeController : Controller {
    public ActionResult Index() {
      ViewData["Message"] = "Welcome to the ScheduleMail ASP.NET MVC API Example !";

      return View();
    }

    public ActionResult About() {
      return View();
    }
  }
}
