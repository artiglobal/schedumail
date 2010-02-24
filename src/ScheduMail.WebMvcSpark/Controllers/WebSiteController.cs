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
        /// Indexes this instance.
        /// </summary>
        /// <returns>View Instance.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns>List View.</returns>
        public ActionResult List()
        {
            IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
            IWebSiteUnitOfWork unitOfWork = factory.GetUnitOfWork();

            ViewData["webSites"] = unitOfWork.List;

            return View();
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>View Instance.</returns>
        public ActionResult Create()
        {
            IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
            IWebSiteUnitOfWork unitOfWork = factory.GetUnitOfWork();

            WebSite site = ViewData["WebSite"] as WebSite;

            SelectList list = CopyToSelectList(0, unitOfWork);
            ViewData["webSites"] = list;

            return View();
        }

        /// <summary>
        /// Creates the specified web site.
        /// </summary>
        /// <param name="webSite">The web site.</param>
        /// <returns>The navigated to view.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(WebSite webSite)
        {
            try
            {
                IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
                IWebSiteUnitOfWork unitOfWork = factory.GetUnitOfWork();

                unitOfWork.Save(webSite);
                ViewData["webSites"] = GetWebSiteList();
                return RedirectToAction("Create");
            }
            catch (RuleException ex)
            {
                ViewData["webSites"] = GetWebSiteList();
                ex.CopyToModelState(ModelState);
                return View();
            }
        }

        /// <summary>
        /// Selectors the specified form.
        /// </summary>
        /// <param name="form">The form.</param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Selector(FormCollection form)
        {
            // Gets the selected website..
            long webSiteId = Convert.ToInt32(form["webSites"]);
            IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
            IWebSiteUnitOfWork unitOfWork = factory.GetUnitOfWork();
            WebSite webSite = unitOfWork.GetById(webSiteId);

            // Set up List of web sites.
            SelectList list = CopyToSelectList(webSiteId, unitOfWork);
            ViewData["webSites"] = list;
            ViewData["DeleteId"] = webSiteId;
            return View("Create", webSite);
        }

        /// <summary>
        /// Finds the first.
        /// </summary>
        /// <param name="form">The form.</param>
        /// <returns>Gets initial view.</returns>
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult FindFirst(FormCollection form)
        {
            /// Gets the selected product.              
            IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
            IWebSiteUnitOfWork unitOfWork = factory.GetUnitOfWork();

            WebSite webSite = unitOfWork.List[0];

            SelectList list = CopyToSelectList(0, unitOfWork);

            ViewData["DeleteId"] = webSite.Id;
            ViewData["webSites"] = list;
            return View("Create", webSite);
        }

        /// <summary>
        /// News the web site.
        /// </summary>
        /// <param name="form">The form.</param>
        /// <returns>Redirection to Create</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult NewWebSite(FormCollection form)
        {

            return RedirectToAction("Create");

        }

        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id instance.</param>
        /// <returns>View Instance.</returns>
        public ActionResult Delete(int id)
        {
            return View();
        }

        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id instance.</param>
        /// <param name="collection">The collection.</param>
        /// <returns>View Instance.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
                IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
                IWebSiteUnitOfWork unitOfWork = factory.GetUnitOfWork();
                if (id.HasValue)
                {
                    WebSite webSite = unitOfWork.GetById(id.Value);
                    unitOfWork.Delete(webSite);
                }

                return RedirectToAction("Create");
            }
            catch
            {
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
            IWebSiteUnitOfWork unitOfWork = factory.GetUnitOfWork();

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
