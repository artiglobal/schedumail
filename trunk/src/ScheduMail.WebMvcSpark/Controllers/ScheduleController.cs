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
    /// Scheduling controller.
    /// </summary>
    public class ScheduleController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>The View Instance.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Detailses the specified id.
        /// </summary>
        /// <param name="id">identification for persistence.</param>
        /// <returns>The View Instance.</returns>
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>The View Instance.</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates the specified collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns>The View Instance.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {              
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Edits the specified id.
        /// </summary>
        /// <param name="id">The identificaion.</param>
        /// <returns>The View Instance.</returns>
        public ActionResult Edit(int id)
        {
            return View();
        }

        /// <summary>
        /// Edits the specified id.
        /// </summary>
        /// <param name="id">The identification passed in.</param>
        /// <param name="collection">The collection.</param>
        /// <returns>The View Instance.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>The View Instance.</returns>
        public ActionResult EditMail(long? id)
        {
            IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
            IMailUnitOfWork unitOfWork = factory.GetMailUnitOfWork();

            Mail mail = unitOfWork.GetById(id.Value);

            return View(mail);            
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>The View Instance.</returns>
       [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditMail(long? id, Mail mail)
        {
            return View();
        }

    }
}
