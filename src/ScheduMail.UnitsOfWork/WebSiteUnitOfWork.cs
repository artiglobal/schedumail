using System.Collections.Generic;
using System.Linq;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.Core.UnitsOfWorkFactory;
using ScheduMail.EFDal.Dal;

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

        #endregion
    }
}
