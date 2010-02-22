using System.Web.Mvc;
using ScheduMail.Core.Domain;
using ScheduMail.Core.UnitsOfWorkFactory;
using ScheduMail.Core.UnitsOfWorkRepository;

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

            return View(unitOfWork.List);
        }

        /// <summary>
        /// Detailses the specified id.
        /// </summary>
        /// <param name="id">The id instance.</param>
        /// <returns>View instance.</returns>
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>View Instance.</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates the specified web site.
        /// </summary>
        /// <param name="webSite">The web site.</param>
        /// <returns>The navigated to view.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "Id")] WebSite webSite)
        {
            try
            {
                IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
                IWebSiteUnitOfWork unitOfWork = factory.GetUnitOfWork();
                unitOfWork.Save(webSite);

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
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
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Edits the specified id.
        /// </summary>
        /// <param name="id">The id instance.</param>
        /// <returns>View Instance.</returns>
        public ActionResult Edit(int id)
        {
            IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
            IWebSiteUnitOfWork unitOfWork = factory.GetUnitOfWork();
            return View(unitOfWork.GetById(id));
        }

        /// <summary>
        /// Edits the specified web site.
        /// </summary>
        /// <param name="webSite">The web site.</param>
        /// <returns>The view instance.</returns>
        [HttpPost]
        public ActionResult Edit(WebSite webSite)
        {
            try
            {
                IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
                IWebSiteUnitOfWork unitOfWork = factory.GetUnitOfWork();

                if (!ModelState.IsValid)
                {
                    return View();
                }

                unitOfWork.Save(webSite);
               
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}
