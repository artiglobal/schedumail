using System.Collections.Generic;
using System.Web.Mvc;
using ScheduMail.Core.Domain;
using ScheduMail.Core.UnitsOfWorkFactory;
using ScheduMail.Core.UnitsOfWorkRepository;

namespace ScheduMail.WebMvcSpark.Controllers
{

    /// <summary>
    /// Web Site EMail Controller.
    /// </summary>
    [Authorize]
    public class WebSiteEMailsController : Controller
    {
        /// <summary>
        /// Indexes the specified web site id.
        /// </summary>
        /// <param name="webSiteId">The web site id.</param>
        /// <returns>List of emails returned.</returns>
        public ActionResult Index(long? webSiteId)
        {
            IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
            IWebSiteUnitOfWork unitOfWork = factory.GetWebSiteUnitOfWork();

            webSiteId = (webSiteId.HasValue == false) ? unitOfWork.List[0].Id : webSiteId;
            IList<WebSiteEMails> webSiteEmails = unitOfWork.GetWebSiteEMails(webSiteId.Value);

            ViewData["webSites"] = this.CopyToSelectList(webSiteId.Value, unitOfWork);

            return View(webSiteEmails);
        }

        #region Private Helpers

        /// <summary>
        /// Gets the web site list.
        /// </summary>
        /// <returns>List of Selected Items.</returns>
        private SelectList GetWebSiteList()
        {
            IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
            IWebSiteUnitOfWork unitOfWork = factory.GetWebSiteUnitOfWork();

            SelectList list = this.CopyToSelectList(0, unitOfWork);
            return list;
        }

        /// <summary>
        /// Copies to select list.
        /// </summary>
        /// <param name="webSiteId">The web site id.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <returns>List of selected items.</returns>
        private SelectList CopyToSelectList(long webSiteId, IWebSiteUnitOfWork unitOfWork)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (ScheduMail.Core.Domain.WebSite item in unitOfWork.List)
            {
                items.Add(new SelectListItem { Text = item.SiteName, Value = item.Id.ToString() });
            }

            SelectList list = new SelectList(items, "Value", "Text", webSiteId);
            return list;
        }

        #endregion
    }
}
