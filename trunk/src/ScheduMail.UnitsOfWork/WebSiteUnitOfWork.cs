using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.Core.UnitsOfWorkFactory;

namespace ScheduMail.UnitsOfWork
{
    /// <summary>
    /// Web site unit of work.
    /// </summary>
    public class WebSiteUnitOfWork : IWebSiteUnitOfWork
    {
        #region IWebSiteUnitOfWork Members

        /// <summary>
        /// Repository handle.
        /// </summary>
        private IWebSiteRepository repository;

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>The repository.</value>
        public IWebSiteRepository Repository
        {
            get { return this.repository; }
            set { this.repository = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebSiteUnitOfWork"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public WebSiteUnitOfWork(IWebSiteRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The Web site list.</value>
        public List<ScheduMail.Core.Domain.WebSite> List
        {
            get
            {
                return this.repository.List.ToList();
            }
        }

        /// <summary>
        /// Gets the web site E mails.
        /// </summary>
        /// <param name="webSiteId">The web site id.</param>
        /// <returns>List Of Web Site EMails</returns>
        public IList<ScheduMail.Core.Domain.WebSiteEMails> GetWebSiteEMails(int webSiteId)
        {
            return this.repository.GetWebSiteEMails(webSiteId).ToList();
        }

        /// <summary>
        /// Get a WebSite instance by id.
        /// </summary>
        /// <param name="id">The Web Site instance id.</param>
        /// <returns>Web Site instance.</returns>
        public ScheduMail.Core.Domain.WebSite GetById(long id)
        {
            return this.repository.GetById(id);
        }

        /// <summary>
        /// Saves the specified web site.
        /// </summary>
        /// <param name="webSite">The web site.</param>
        /// <returns>Updated Web site instance.</returns>
        public ScheduMail.Core.Domain.WebSite Save(ScheduMail.Core.Domain.WebSite webSite)
        {
            var errors = this.GetRuleViolations(webSite);
            if (errors.Count > 0)
            {
                throw new RuleException(errors);
            }

            return this.repository.Save(webSite);
        }

        /// <summary>
        /// Deletes the specified web site.
        /// </summary>
        /// <param name="webSite">The web site.</param>
        public void Delete(ScheduMail.Core.Domain.WebSite webSite)
        {
            this.repository.Delete(webSite);
        }

        /// <summary>
        /// Gets the rule violations.
        /// </summary>
        /// <param name="webSite">The web site.</param>
        /// <returns>Collection of Rules Violations.</returns>
        private NameValueCollection GetRuleViolations(ScheduMail.Core.Domain.WebSite webSite)
        {
            var errors = new NameValueCollection();

            if (string.IsNullOrEmpty(webSite.SiteName))
            {
                errors.Add("SiteName", "Site Name is required");
            }

            if (webSite.SiteName.Length > 255)
            {
                errors.Add("SiteName", "Site Name max length exceeded");
            }

            if (string.IsNullOrEmpty(webSite.Template))
            {
                errors.Add("Template", "Template is required");
            }

            return errors;
        }

        #endregion
    }
}
