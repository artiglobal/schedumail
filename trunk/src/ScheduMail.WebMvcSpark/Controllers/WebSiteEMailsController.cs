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
    /// Web Site EMail Controller.
    /// </summary>
    public class WebSiteEMailsController : Controller
    {
        /// <summary>
        /// Indexes the specified user E mail id.
        /// </summary>
        /// <param name="UserEMailId">The user E mail id.</param>
        /// <returns>List of Web Site EMails.</returns>
        public ActionResult Index(long? WebSiteId)
        {
            IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
            IWebSiteUnitOfWork unitOfWork = factory.GetWebSiteUnitOfWork();

            WebSiteId = (WebSiteId.HasValue == false) ? unitOfWork.List[0].Id : WebSiteId;
            IList<WebSiteEMails> webSiteEmails = unitOfWork.GetWebSiteEMails(WebSiteId.Value);

            ViewData["webSites"] = CopyToSelectList(WebSiteId.Value, unitOfWork);

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

            SelectList list = CopyToSelectList(0, unitOfWork);
            return list;
        }

        /// <summary>
        /// Copies to select list.
        /// </summary>
        /// <param name="webSiteId">The web site id.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <returns></returns>
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
