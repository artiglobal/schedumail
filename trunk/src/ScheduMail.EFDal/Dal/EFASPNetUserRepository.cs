using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.DBModel;
using ScheduMail.Utils;

namespace ScheduMail.EFDal.Dal
{
    /// <summary>
    /// ASPNet Users Repository.
    /// </summary>
    public class EFAspNetUsersRepository : IASPNetUserRepository
    {
        #region Private Members

        /// <summary>
        /// ADO.net entity context handle
        /// </summary>
        private ScheduMailDBEntities context;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="EFAspNetUsersRepository"/> class.
        /// </summary>
        public EFAspNetUsersRepository()
        {
            this.context = new ScheduMailDBEntities();
        }

        #endregion

        #region ICrudRepository<ScheduMail,int> Members

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The list of users.</value>
        public IQueryable<ScheduMail.Core.Domain.AspnetUsers> List
        {
            get
            {
                return ObjectExtension
                          .CloneList<ScheduMail.DBModel.aspnet_Users,
                                ScheduMail.Core.Domain.AspnetUsers>
                                     (this.context.aspnet_Users.ToList<ScheduMail.DBModel.aspnet_Users>())
                                     .OrderBy(q => q.CreateDate)
                          .AsQueryable();
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The userid.</param>
        /// <returns>Website instance.</returns>
        public ScheduMail.Core.Domain.AspnetUsers GetById(string id)
        {
            var entity = (from w in this.context.aspnet_Users.Include("WebSite")
                          where w.UserId == id
                          select w).First();
            ScheduMail.Core.Domain.AspnetUsers coreUser = ObjectExtension.CloneProperties<ScheduMail.DBModel.aspnet_Users, ScheduMail.Core.Domain.AspnetUsers>(entity);
            List<ScheduMail.Core.Domain.WebSite> webSites =
                ObjectExtension.CloneList<ScheduMail.DBModel.WebSite, 
                    ScheduMail.Core.Domain.WebSite>(entity.WebSite.ToList<ScheduMail.DBModel.WebSite>());
            coreUser.WebSites = webSites;
            return coreUser;
        }

        /// <summary>
        /// Lists the by web site id.
        /// </summary>
        /// <param name="id">The identification value.</param>
        /// <returns>AspNetUser instance.</returns>
        public IQueryable<ScheduMail.Core.Domain.AspnetUsers> ListByWebSiteId(long id)
        {
            // Note heres an example of how to use an SQL Query J.I.C this doesn't work
            // context.CreateQuery(@"SELECT VALUE Customer FROM Customer 
            // WHERE EXISTS( SELECT VALUE FROM CustomerInterest 
            // WHERE CustomerInterest.Ineterest.Name = 'FootBall')).Include("Interest");
            var users = (from w in this.context.WebSites
                         from u in w.aspnet_Users
                         where w.Id == id
                         select u).ToList<ScheduMail.DBModel.aspnet_Users>();

            return ObjectExtension
                      .CloneList<ScheduMail.DBModel.aspnet_Users,
                            ScheduMail.Core.Domain.AspnetUsers>
                                 (users)
                                 .OrderBy(q => q.CreateDate)
                      .AsQueryable();
        }

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="user">The user instance.</param>
        /// <param name="isAdministrator">if set to <c>true</c> [is administrator].</param>
        /// <param name="selectedWebSites">The selected web sites.</param>
        /// <returns>Saved user instance.</returns>
        public ScheduMail.Core.Domain.AspnetUsers Save(ScheduMail.Core.Domain.AspnetUsers user, bool isAdministrator, string[] selectedWebSites)
        {
            // Strategy takes account of the fact that users will have already been added
            // through web forms. This strategy is clearly not optimal, so for now typical code has been added
            // to account for this strategy. this can be modified as fit.
            // Note currently usernames are email addresses which doesn;t make sense as there is a seperate email address
            // to add on specification. Suggest that username is provided as a unique name and email address is added seperately.

            // First check that user supplied has already been added through webadmin.
            MembershipUser memberShipUser = Membership.GetUser(user.Username);
            if (memberShipUser == null)
            {
                throw new RuleException("Username", "User entered does not exist, add user using admin facility");
            }

            // Next read existing user and associated website records (website records reflect many-to- many relationship between
            // usr and web sites.
            ScheduMail.DBModel.aspnet_Users entityUser =
                this.context.aspnet_Users.Include("WebSite")
                .Where(q => q.Username == memberShipUser.UserName).First();

            entityUser.Email = user.Email;

            // Clean up any existing website associations.
            int count = entityUser.WebSite.Count;
            for (int i = 0; i < count; i++)
            {
                entityUser.WebSite.Remove(entityUser.WebSite.ElementAt(0));
            }
           
            // if there are any website associations to add
            // associate websites with user. Note will add entries to userwebsite.
            if (selectedWebSites != null)
            {
                foreach (string website in selectedWebSites)
                {
                    long entityWebSiteId = Convert.ToInt64(website);
                    ScheduMail.DBModel.WebSite entityWebSite = this.context.WebSites.Where(q => q.Id == entityWebSiteId).First();
                    entityUser.WebSite.Add(entityWebSite);
                }
            }

            // persist changes
            this.context.SaveChanges();

            string[] roles = { "Admin" };

            // Check is user is / or should be in admin role.
            if (isAdministrator == true)
            {
                if (!Roles.IsUserInRole(user.Username, "Admin"))
                {
                    Roles.AddUserToRoles(user.Username, roles);
                }
            }
            else
            {
                if (Roles.IsUserInRole(user.Username, "Admin"))
                {
                    Roles.RemoveUserFromRole(user.Username, "Admin");
                }
            }

            return ObjectExtension.CloneProperties<ScheduMail.DBModel.aspnet_Users, ScheduMail.Core.Domain.AspnetUsers>(entityUser);
        }

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="webSite">The website instance.</param>
        /// <returns>Changed user.</returns>
        public ScheduMail.Core.Domain.AspnetUsers Save(ScheduMail.Core.Domain.AspnetUsers webSite)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified user.
        /// </summary>
        /// <param name="user">The user instance.</param>
        public void Delete(ScheduMail.Core.Domain.AspnetUsers user)
        {
            var entity = (from u in this.context.aspnet_Users.Include("WebSite")
                          where u.UserId == user.UserId
                          select u).First();

            for (int i = 0; i < entity.WebSite.Count; i++)
            {
                entity.WebSite.Remove(entity.WebSite.ElementAt(0));
            }

            this.context.SaveChanges();
        }

        #endregion
    }
}
