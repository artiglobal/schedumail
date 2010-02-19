using System.Linq;
using System.Web.Mvc;
using ScheduMail.Core.Domain;
using ScheduMail.Core.RepositoryInterfaces;

namespace ScheduMail.WebMvc2.Controllers
{
    /// <summary>
    /// Home controller class.
    /// </summary>
    [HandleError]
    public class HomeController : Controller
    {
        /// <summary>
        /// Repository instance.
        /// </summary>
        private IEBookRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public HomeController(IEBookRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>The view instnce.</returns>
        public ActionResult Index()
        {
            return View(this.repository.ListEbook().ToList<Book>());
        }

        /// <summary>
        /// Abouts this instance.
        /// </summary>
        /// <returns>The view instance.</returns>
        public ActionResult About()
        {
            return View();
        }
    }
}
