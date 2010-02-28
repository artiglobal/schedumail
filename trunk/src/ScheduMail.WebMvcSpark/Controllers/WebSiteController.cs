using System.Collections.Generic;
using System.Web.Mvc;
using ScheduMail.Core.Domain;
using ScheduMail.Core.UnitsOfWorkFactory;
using ScheduMail.Core.UnitsOfWorkRepository;
using ScheduMail.WebMvcSpark.Extensions;

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
        /// <param name="webSiteId">The web site id.</param>
        /// <param name="submitButton">The submit button.</param>
        /// <returns>The view instance.</returns>
        public ActionResult EditWebSite(int? webSiteId, string submitButton)
        {
            IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
            IWebSiteUnitOfWork unitOfWork = factory.GetWebSiteUnitOfWork();

            SelectList list = this.CopyToSelectList(0, unitOfWork);
            ViewData["webSites"] = list;

            // Deal with adding new Web Site
            if (webSiteId == -1)
            {
                return View(new WebSite { });
            }

            // if webSiteId supplied get search websites otherwise default to the first webSite.
            return View(webSiteId.HasValue ? unitOfWork.GetById(webSiteId.Value) : unitOfWork.List[0]);
        }

        /// <summary>
        /// Edits the web site.
        /// </summary>
        /// <param name="webSiteId">The web site id.</param>
        /// <param name="submitButton">The submit button.</param>
        /// <param name="webSite">The web site.</param>
        /// <returns>The action result.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult EditWebSite(int? webSiteId, string submitButton, WebSite webSite)
        {
            try
            {
                IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
                IWebSiteUnitOfWork unitOfWork = factory.GetWebSiteUnitOfWork();

                SelectList list = this.CopyToSelectList(0, unitOfWork);
                ViewData["webSites"] = this.GetWebSiteList();

                switch (submitButton)
                {
                    case "Add New Web Site":
                        // reset so displays default value                        
                        return RedirectToAction("EditWebSite", new { WebSiteId = -1 });
                    case "Save":
                        unitOfWork.Save(webSite);
                        int? tempVal = null;
                        return RedirectToAction("EditWebSite", new { WebSiteId = tempVal });
                    case "Delete":
                        webSite = unitOfWork.GetById(webSiteId.Value);
                        unitOfWork.Delete(webSite);
                        tempVal = null;
                        return RedirectToAction("EditWebSite", new { WebSiteId = tempVal });
                    default: // Change of drop down list ...                                           
                        return RedirectToAction("EditWebSite", new { WebSiteId = webSiteId });
                }
            }
            catch (RuleException ex)
            {
                ViewData["webSites"] = this.GetWebSiteList();
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

            SelectList list = this.CopyToSelectList(0, unitOfWork);
            return list;
        }

        /// <summary>
        /// Copies to select list.
        /// </summary>
        /// <param name="webSiteId">The web site id.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <returns>List of select items.</returns>
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
