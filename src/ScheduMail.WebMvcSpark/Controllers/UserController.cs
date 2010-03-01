using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using ScheduMail.Core.Domain;
using ScheduMail.Core.UnitsOfWorkFactory;
using ScheduMail.Core.UnitsOfWorkRepository;
using ScheduMail.UnitsOfWork;
using ScheduMail.WebMvcSpark.Extensions;

namespace ScheduMail.WebMvcSpark.Controllers
{
    /// <summary>
    /// User controller used for managing users.
    /// </summary>
    public class UserController : Controller
    {
        /// <summary>
        /// Indexes the specified web site id.
        /// </summary>
        /// <param name="webSiteId">The web site id.</param>
        /// <returns>The view instance.</returns>
        public ActionResult Index(long? webSiteId)
        {
            IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();

            IWebSiteUnitOfWork webSitesUnitOfWork = factory.GetWebSiteUnitOfWork();
            List<WebSite> webSites = webSitesUnitOfWork.List;
            webSiteId = (webSiteId.HasValue == true) ? webSiteId : webSites[0].Id;
            ViewData["webSites"] = this.CopyToSelectList(webSiteId.Value, webSites);

            IAspNetUnitOfWork aspNetUserUnitOfWork = factory.GetAspNetUnitOfWork();
            List<AspnetUsers> users = aspNetUserUnitOfWork.ListByWebSiteId(webSiteId.Value);

            return View(users);
        }

        /// <summary>
        /// Detailses the specified id.
        /// </summary>
        /// <param name="id">The identification value.</param>
        /// <returns>The view instance.</returns>
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>The view instance.</returns>
        public ActionResult Create()
        {
            ViewData["userWebSites"] = GetUserWebSitesForCreate();
            AspnetUsers user = new AspnetUsers();
            return View(user);
        }

        /// <summary>
        /// Creates the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="email">The email instance.</param>
        /// <param name="selectedObjects">The selected objects.</param>
        /// <param name="isAdministrator">if set to <c>true</c> [is administrator].</param>
        /// <param name="collection">The collection.</param>
        /// <returns>The view instance.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(string userName, string email, string[] selectedObjects, bool isAdministrator, FormCollection collection)
        {
            // Note checkboxes require special handling in mvc
            // Posts Render an additional <input type="hidden".../> for checkboxes if checked which provides a true and false value.
            // This addresses scenarios where unchecked checkboxes are not sent in the request. 
            // Sending a hidden input makes it possible to know that the checkbox 
            // was present on the page when the request was submitted.
            // as a result of this querying formas parameters produces unexpected results. The workaround institued for
            // this problem takes account that only checkboxes which are selected/changed in selected Objects as passed.
            // Inspect the key value to work out what has changed.       
            try
            {
                IUnitOfWorkFactory factory = new WebSiteUnitOfWorkFactory();
                IAspNetUnitOfWork unitOfWork = factory.GetAspNetUnitOfWork();

                ViewData["userWebSites"] = GetUserWebSitesForCreate();
                AspnetUsers user = new AspnetUsers
                {
                    Username = userName,
                    Email = email
                };

                user = unitOfWork.Save(user, isAdministrator, selectedObjects);

                return RedirectToAction("Index");
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
        /// Edits the specified id.
        /// </summary>
        /// <param name="id">The identification value.</param>
        /// <returns>The view instance.</returns>
        public ActionResult Edit(string id)
        {
            List<UserWebSite> userWebSites = GetUserWebSitesForCreate();

            IUnitOfWorkFactory factory = new WebSiteUnitOfWorkFactory();
            IAspNetUnitOfWork unitOfWork = factory.GetAspNetUnitOfWork();

            AspnetUsers user = unitOfWork.GetById(id);
            ViewData["isAdministrator"] = Roles.IsUserInRole(user.Username, "Admin");

            List<CheckBoxListInfo> checkBoxListItems = new List<CheckBoxListInfo>();
            foreach (UserWebSite userWebSite in userWebSites)
            {
                bool isChecked = false;
                if (user.WebSites.Find(q => q.Id == userWebSite.WebSiteId) != null)
                {
                    isChecked = true;
                }
                CheckBoxListInfo info =
                   new CheckBoxListInfo(userWebSite.WebSiteId.ToString(), userWebSite.SiteName, isChecked);
                checkBoxListItems.Add(info);
            }

            ViewData["listItems"] = checkBoxListItems;

            return View(user);
        }

        /// <summary>
        /// Edits the specified id.
        /// </summary>
        /// <param name="id">The identification value.</param>
        /// <param name="submitButton">The submit button.</param>
        /// <param name="collection">The collection.</param>
        /// <returns>The view instance.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int? id, string submitButton, string[] listItems, FormCollection collection)
        {
            try
            {
                switch (submitButton)
                {
                    case "Save":
                        // delegate sending to another controller action 
                        return RedirectToAction("Index");
                    case "Delete":
                        // call another action to perform the cancellation 
                        return RedirectToAction("Index");
                    default:
                        // If they've submitted the form without a submitButton,  
                        // just return the view again. 
                        return RedirectToAction("Index");
                }
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
        /// <returns>The view instance.</returns>
        private static MembershipUser[] GetUsers()
        {
            MembershipUserCollection userCollection = Membership.GetAllUsers();
            MembershipUser[] members = new MembershipUser[userCollection.Count];
            userCollection.CopyTo(members, 0);
            return members;
        }

        /// <summary>
        /// Copies to select list.
        /// </summary>
        /// <param name="webSiteId">The web site id.</param>
        /// <param name="webSites">The list of websites.</param>
        /// <returns>List of Select items.</returns>
        private SelectList CopyToSelectList(long webSiteId, List<WebSite> webSites)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (ScheduMail.Core.Domain.WebSite item in webSites)
            {
                items.Add(new SelectListItem { Text = item.SiteName, Value = item.Id.ToString() });
            }

            SelectList list = new SelectList(items, "Value", "Text", webSiteId);
            return list;
        }

        /// <summary>
        /// Gets the user web sites for create.
        /// </summary>
        /// <returns>List of Use Web sites with UserSubscribedToWebSite == false.</returns>
        private static List<UserWebSite> GetUserWebSitesForCreate()
        {
            IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
            IWebSiteUnitOfWork webSitesUnitOfWork = factory.GetWebSiteUnitOfWork();
            List<WebSite> webSites = webSitesUnitOfWork.List;

            List<UserWebSite> userWebSites = new List<UserWebSite>();
            Action<WebSite> action = new Action<WebSite>(q => userWebSites.Add(new UserWebSite
            {
                SiteName = q.SiteName,
                UserSubscribedToWebSite = false,
                WebSiteId = q.Id
            }));

            webSites.ForEach(action);

            return userWebSites;
        }

        /// <summary>
        /// Gets the web sites.
        /// </summary>
        /// <returns>List of Web sites.</returns>
        private static List<WebSite> GetWebSites()
        {
            IUnitOfWorkFactory factory = new ScheduMail.UnitsOfWork.WebSiteUnitOfWorkFactory();
            IWebSiteUnitOfWork webSitesUnitOfWork = factory.GetWebSiteUnitOfWork();
            return webSitesUnitOfWork.List;
        }

        #endregion
    }
}
