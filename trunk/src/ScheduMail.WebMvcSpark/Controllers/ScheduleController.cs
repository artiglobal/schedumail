using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace ScheduMail.WebMvcSpark.Controllers
{
    public class ScheduleController : Controller
    {
        //
        // GET: /Schedule/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Schedule/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Schedule/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Schedule/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Schedule/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Schedule/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}