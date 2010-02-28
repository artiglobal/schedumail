using System.Web.Mvc;
using ScheduMail.Core.Domain;
using ScheduMail.Core.UnitsOfWorkFactory;
using ScheduMail.Core.UnitsOfWorkRepository;

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
        /// <param name="id">The log event id.</param>
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
