using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.Core.UnitsOfWorkFactory;

namespace ScheduMail.UnitsOfWork
{
    /// <summary>
    /// user unit of work.
    /// </summary>
    public class AspNetUserOfWork : IAspNetUnitOfWork
    {
        #region IAspNetUserOfWork Members

        /// <summary>
        /// Repository handle.
        /// </summary>
        private IASPNetUserRepository repository;

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>The repository.</value>
        public IASPNetUserRepository Repository
        {
            get { return this.repository; }
            set { this.repository = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AspNetUserOfWork"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public AspNetUserOfWork(IASPNetUserRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The user list.</value>
        public List<ScheduMail.Core.Domain.AspnetUsers> List
        {
            get
            {
                return this.repository.List.ToList();
            }
        }

        /// <summary>
        /// Gets the ASP ner users by id.
        /// </summary>
        /// <param name="id">The identification passed.</param>
        /// <returns>List of ASP net Users.</returns>
        public List<ScheduMail.Core.Domain.AspnetUsers> ListByWebSiteId(long id)
        {
            return this.repository.ListByWebSiteId(id).ToList<ScheduMail.Core.Domain.AspnetUsers>();
        }

        /// <summary>
        /// Get a Mail instance by id.
        /// </summary>
        /// <param name="id">The users instance id.</param>
        /// <returns>users instance.</returns>
        public ScheduMail.Core.Domain.AspnetUsers GetById(string id)
        {
            return this.repository.GetById(id);
        }

        /// <summary>
        /// Saves the specified users.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <param name="isAdministrator">if set to <c>true</c> [is administrator].</param>
        /// <param name="selectedWebSites">The selected web sites.</param>
        /// <returns>Updated user instance.</returns>
        public ScheduMail.Core.Domain.AspnetUsers Save(ScheduMail.Core.Domain.AspnetUsers users, bool isAdministrator, string[] selectedWebSites)
        {
            var errors = this.GetRuleViolations(users);
            if (errors.Count > 0)
            {
                throw new RuleException(errors);
            }

            return this.repository.Save(users, isAdministrator, selectedWebSites);
        }

        /// <summary>
        /// Deletes the specified users.
        /// </summary>
        /// <param name="user">The user instance.</param>
        public void Delete(ScheduMail.Core.Domain.AspnetUsers user)
        {
            this.repository.Delete(user);
        }

        /// <summary>
        /// Gets the rule violations.
        /// </summary>
        /// <param name="user">The users.</param>
        /// <returns>Collection of Rules Violations.</returns>
        private NameValueCollection GetRuleViolations(ScheduMail.Core.Domain.AspnetUsers user)
        {
            var errors = new NameValueCollection();

            if (user.Username.Length > 50)
            {
                errors.Add("Username", "Username is required");
            }

            if (String.IsNullOrEmpty(user.Email))
            {
                errors.Add("Username", "Username is required");
            }

            if (user.Email.Length > 50)
            {
                errors.Add("Email", "EMail is required");
            }

            if (String.IsNullOrEmpty(user.Email))
            {
                errors.Add("Email", "EMail is required");
            }

            return errors;
        }

        #endregion
    }
}
