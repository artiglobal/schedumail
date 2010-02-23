using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScheduMail.WebMvc2.Controllers
{
    /// <summary>
    /// User Communcations Conteoller.
    /// </summary>
    public class UserCommunicationsController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>The instance view.</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
