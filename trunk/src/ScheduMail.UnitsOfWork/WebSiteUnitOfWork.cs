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
        /// Gets the list.
        /// </summary>
        /// <value>The Web site list.</value>
        public List<ScheduMail.Core.Domain.WebSite> List
        {
            get
            {
                IWebSiteRepository repository = new EFWebSiteRepository();
                return repository.List.ToList();
            }
        }

        /// <summary>
        /// Get a WebSite instance by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Web Site instance.</returns>
        public ScheduMail.Core.Domain.WebSite GetById(long id)
        {
            IWebSiteRepository repository = new EFWebSiteRepository();
            return repository.GetById(id);
        }


        /// <summary>
        /// Saves the specified web site.
        /// </summary>
        /// <param name="webSite">The web site.</param>
        /// <returns>Updated Web site instance.</returns>
        public ScheduMail.Core.Domain.WebSite Save(ScheduMail.Core.Domain.WebSite webSite)
        {
            IWebSiteRepository repository = new EFWebSiteRepository();
            return repository.Save(webSite);
        }

        /// <summary>
        /// Deletes the specified web site.
        /// </summary>
        /// <param name="webSite">The web site.</param>
        public void Delete(ScheduMail.Core.Domain.WebSite webSite)
        {
            IWebSiteRepository repository = new EFWebSiteRepository();
            repository.Delete(webSite);
        }

        #endregion      
    }
}
