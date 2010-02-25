using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScheduMail.WebMvcSpark.Controllers
{
    /// <summary>
    /// Home Controller.
    /// </summary>
    [HandleError]
    public class HomeController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>The view instance.</returns>
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";           

            return View();
        }

        /// <summary>
        /// Abouts this instance.
        /// </summary>
        /// <returns>The view instance.</returns>
        public ActionResult About()
        {
            return View();
        }
    }
}
