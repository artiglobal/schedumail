using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ScheduMail.Core.UnitsOfWorkRepository;
using ScheduMail.Core.UnitsOfWorkFactory;
using ScheduMail.Core.Domain;
using System.Xml;

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
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index(int? id)
        {
            SelectList hoursList = CopyToSelectList("/App_Data/Hours.xml", -1);
            SelectList minutesList = CopyToSelectList("/App_Data/Minutes.xml", -1);
            ViewData["hoursList"] = hoursList;
            ViewData["minutesList"] = minutesList;

            if (id.HasValue)
            {
                IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();

                IMailUnitOfWork mailUnitOfWork = factory.GetMailUnitOfWork();
                Mail mail = mailUnitOfWork.GetById(id.Value);
            }
            
            
            return View();
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>The View Instance.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(int? id, string submitButton,Schedule schedule, FormCollection collection)
        {
            try
            {
                SelectList hoursList = CopyToSelectList("/App_Data/Hours.xml", -1);
                SelectList minutesList = CopyToSelectList("/App_Data/Minutes.xml", -1);
                ViewData["hoursList"] = hoursList;
                ViewData["minutesList"] = minutesList;
            
                switch (submitButton)
                {
                    case "Save":
                        // delegate sending to another controller action 
                        schedule.DaysOfWeekToRun = collection["DaysOfWeekToRun"];

                        return View("Index", schedule);
                }
            }
            catch
            {
                return View();
            }

           


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

            Mail mail = (id.HasValue) ? unitOfWork.GetById(id.Value) : new Mail();

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

        /// <summary>
        /// Copies to select list.
        /// </summary>
        /// <param name="Id">id for selection list.</param>
        /// <param name="source">source of XMl file</param>
        /// <returns>SelectList</returns>
        private SelectList CopyToSelectList(string source ,long Id)
        {

            List<SelectListItem> items = new List<SelectListItem>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(HttpContext.Request.PhysicalApplicationPath + source);
            XmlNodeList xmlNodeList = xmlDoc.SelectNodes("/languages/language");
            foreach (XmlNode node in xmlNodeList)
                items.Add(new SelectListItem { Text = node.Attributes["name", ""].Value, Value = node.Attributes["value", ""].Value });
            SelectList list = new SelectList(items, "Value", "Text", Id);
            return list;
        }
    }
}
