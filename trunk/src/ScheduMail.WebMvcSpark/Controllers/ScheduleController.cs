using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using ScheduMail.Core.Domain;
using ScheduMail.Core.UnitsOfWorkFactory;
using ScheduMail.Core.UnitsOfWorkRepository;
using ScheduMail.UnitsOfWork;
using ScheduMail.WebMvcSpark.Extensions;

namespace ScheduMail.WebMvcSpark.Controllers
{

    /// <summary>
    /// Scheduling controller.
    /// </summary>
    public class ScheduleController : Controller
    {
        /// <summary>
        /// Indexes the specified id.
        /// </summary>
        /// <param name="id">The identification value.</param>
        /// <returns>The view instance.</returns>
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index(int? id)
        {
            SelectList hoursList = this.CopyToSelectList("/App_Data/Hours.xml", -1);
            SelectList minutesList = this.CopyToSelectList("/App_Data/Minutes.xml", -1);
            ViewData["hoursList"] = hoursList;
            ViewData["minutesList"] = minutesList;

            if (id.HasValue)
            {
                IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
                IMailUnitOfWork mailUnitOfWork = factory.GetMailUnitOfWork();
                Mail mail = mailUnitOfWork.GetById(id.Value);
                ViewData["mail"] = mail;

                IScheduleUnitOfWork scheduleUnitOfWork = factory.GetScheduleUnitOfWork();
                Schedule schedule = scheduleUnitOfWork.GetByMailId(mail.Id);
                ViewData["schedule"] = schedule;

            }

            return View();
        }

        /// <summary>
        /// Indexes the specified id.
        /// </summary>
        /// <param name="id">The identification value.</param>
        /// <param name="submitButton">The submit button.</param>
        /// <param name="schedule">The schedule.</param>
        /// <param name="collection">The collection.</param>
        /// <returns>The view instance.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(long? Id, string submitButton, Schedule schedule, FormCollection collection)
        {
            try
            {
                SelectList hoursList = this.CopyToSelectList("/App_Data/Hours.xml", -1);
                SelectList minutesList = this.CopyToSelectList("/App_Data/Minutes.xml", -1);
                ViewData["hoursList"] = hoursList;
                ViewData["minutesList"] = minutesList;

                switch (submitButton)
                {
                    case "Save":
                        // delegate sending to another controller action 
                        schedule.DaysOfWeekToRun = collection["DaysOfWeekToRun"];
                        schedule.Enabled = Convert.ToBoolean(collection["collection"]);
                        schedule.CreatedBy = User.Identity.Name;
                        IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
                        IScheduleUnitOfWork scheduleUnitOfWork = factory.GetScheduleUnitOfWork();
                        if (Id.HasValue)
                        {
                            schedule.MailId = (long)Id;
                            schedule.Id = scheduleUnitOfWork.GetByMailId(schedule.MailId).Id;
                            
                        }
                        //IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
                        //IScheduleUnitOfWork scheduleUnitOfWork = factory.GetScheduleUnitOfWork();
                        scheduleUnitOfWork.Save(schedule);

                        // IMailUnitOfWork mailUnitOfWork = factory.GetMailUnitOfWork();
                        //Mail mail = mailUnitOfWork.GetById(id.Value);

                        return View("Index", schedule);
                }
                return View("Index", schedule);
            }

            catch (RuleException ex)
            {

                ex.CopyToModelState(ModelState);
                return View();
            }
            catch (Exception ex)
            {
                RuleException rex = new RuleException("error", ex.Message);
                rex.CopyToModelState(ModelState);
                return View();
            }
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
        /// Edits the mail.
        /// </summary>
        /// <param name="id">The identification value.</param>
        /// <returns>The view instance.</returns>
        public ActionResult EditMail(long? id)
        {
            IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
            IMailUnitOfWork unitOfWork = factory.GetMailUnitOfWork();

            Mail mail = id.HasValue ? unitOfWork.GetById(id.Value) : new Mail();

            return View(mail);
        }

        /// <summary>
        /// Edits the mail.
        /// </summary>
        /// <param name="id">The identification value.</param>
        /// <param name="mail">The mail instance.</param>
        /// <returns>The instance view.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditMail(long? id, Mail mail)
        {
            return View();
        }

        /// <summary>
        /// Copies to select list.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="id">The identification value.</param>
        /// <returns>Select list of items.</returns>
        private SelectList CopyToSelectList(string source, long id)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(HttpContext.Request.PhysicalApplicationPath + source);
            XmlNodeList xmlNodeList = xmlDoc.SelectNodes("/languages/language");
            foreach (XmlNode node in xmlNodeList)
            {
                items.Add(new SelectListItem { Text = node.Attributes["name", String.Empty].Value, Value = node.Attributes["value", String.Empty].Value });
            }

            SelectList list = new SelectList(items, "Value", "Text", id);
            return list;
        }
    }
}
