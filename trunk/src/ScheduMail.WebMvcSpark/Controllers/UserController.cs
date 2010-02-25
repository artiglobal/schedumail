using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Security;

namespace ScheduMail.WebMvcSpark.Controllers
{
    /// <summary>
    /// User controller used for managing users.
    /// </summary>
    public class UserController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<MembershipUser> myUsers = GetUsers()
                .OrderBy(q => q.UserName)
                .ToList<MembershipUser>();         

            return View(myUsers);
        }      

        /// <summary>
        /// Detailses the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates the specified collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Edits the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            return View();
        }

        /// <summary>
        /// Edits the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="collection">The collection.</param>
        /// <returns></returns>
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

        #region Private Helper Methods

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        private static MembershipUser[] GetUsers()
        {
            MembershipUserCollection userCollection = Membership.GetAllUsers();           
            MembershipUser[] members = new MembershipUser[userCollection.Count];
            userCollection.CopyTo(members, 0);            
            return members;
        }

        #endregion
    }
}
