using System.Web.Mvc;
using ScheduMail.Core.Domain;
using ScheduMail.Core.UnitsOfWorkFactory;
using ScheduMail.Core.UnitsOfWorkRepository;
using ScheduMail.WebMvcSpark.Extensions;
using System;
using System.Collections.Generic;

namespace ScheduMail.WebMvc2.Controllers
{
    /// <summary>
    /// Web site controller.
    /// </summary>
    public class WebSiteController : Controller
    {
        /// <summary>
        /// Edits the web site.
        /// </summary>
        /// <param name="WebSiteId">The web site id.</param>
        /// <param name="submitButton">The submit button.</param>
        /// <returns></returns>
        public ActionResult EditWebSite(int? WebSiteId, string submitButton)
        {
            IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
            IWebSiteUnitOfWork unitOfWork = factory.GetWebSiteUnitOfWork();

            SelectList list = CopyToSelectList(0, unitOfWork);
            ViewData["webSites"] = list;

            // Deal with adding new Web Site
            if (WebSiteId == -1) return View(new WebSite { });

            return View(((WebSiteId.HasValue) ? unitOfWork.GetById(WebSiteId.Value) : unitOfWork.List[0]));
        }

        /// <summary>
        /// Edits the web site.
        /// </summary>
        /// <param name="WebSiteId">The web site id.</param>
        /// <param name="submitButton">The submit button.</param>
        /// <param name="webSite">The web site.</param>
        /// <returns>The Action Result.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult EditWebSite(int? WebSiteId, string submitButton, WebSite webSite)
        {
            try
            {
                IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
                IWebSiteUnitOfWork unitOfWork = factory.GetWebSiteUnitOfWork();

                SelectList list = CopyToSelectList(0, unitOfWork);
                ViewData["webSites"] = list;

                switch (submitButton)
                {
                    case "Add New Web Site":
                        return RedirectToAction("EditWebSite", new { WebSiteId = -1 });
                    case "Save":
                        unitOfWork.Save(webSite);
                        ViewData["webSites"] = GetWebSiteList();
                        return View();
                    case "Delete":
                        webSite = unitOfWork.GetById(WebSiteId.Value);
                        unitOfWork.Delete(webSite);
                        int? tempVal = null;
                        return RedirectToAction("EditWebSite", new { WebSiteId = tempVal });
                    default: // Change of drop down list ...                                           
                        return RedirectToAction("EditWebSite", new { WebSiteId = WebSiteId });
                }
            }
            catch (RuleException ex)
            {
                ViewData["webSites"] = GetWebSiteList();
                ex.CopyToModelState(ModelState);
                return View();
            }
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
