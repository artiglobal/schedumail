using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ScheduMail.Core.UnitsOfWorkRepository;
using ScheduMail.Core.UnitsOfWorkFactory;
using ScheduMail.Core.Domain;

namespace ScheduMail.WebMvcSpark.Controllers
{
    /// <summary>
    /// Log Event controller.
    /// </summary>
    public class LogEventController : Controller
    {
        /// <summary>
        /// Details the specified log event id.
        /// </summary>
        /// <param name="logEventId">The log event id.</param>
        /// <returns>The view instance.</returns>
        public ActionResult Detail(long? id)
        {
            IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
            IlogEventUnitOfWork unitOfWork = factory.GetLogEventUnitOfWork();

            LogEvent logEvent = unitOfWork.GetById(id.Value);

            return View(logEvent);
        }

    }
}
