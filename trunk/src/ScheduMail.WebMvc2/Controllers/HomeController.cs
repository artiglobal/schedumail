using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.Core.Domain;


namespace ScheduMail.WebMvc2.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private IEBookRepository _repository;
        public HomeController(IEBookRepository repository)
        {
            this._repository = repository;
        }

        public ActionResult Index()
        {           
            return View(_repository.ListEbook().ToList<Book>());
        }    

        public ActionResult About()
        {
            return View();
        }
    }
}
