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
        /// Saves the specified user.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns>Updated user instance.</returns>
        public ScheduMail.Core.Domain.AspnetUsers Save(ScheduMail.Core.Domain.AspnetUsers users)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified users.
        /// </summary>
        /// <param name="users">The users.</param>
        public void Delete(ScheduMail.Core.Domain.AspnetUsers users)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the rule violations.
        /// </summary>
        /// <param name="user">The users.</param>
        /// <returns>Collection of Rules Violations.</returns>
        private NameValueCollection GetRuleViolations(ScheduMail.Core.Domain.AspnetUsers user)
        {
            var errors = new NameValueCollection();

            return errors;
        }

        #endregion
    }
}
