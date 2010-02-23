using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduMail.Core.RepositoryInterfaces;

namespace ScheduMail.Core.FakeRepositories
{
    /// <summary>
    /// Fake Web site repository used to test web site
    /// </summary>
    public class FakeWebSiteRepository : IWebSiteRepository
    {
        #region ICrudRepository<WebSite,int> Members

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The list of Web sites.</value>
        public IQueryable<ScheduMail.Core.Domain.WebSite> List
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The website identification.</param>
        /// <returns>Website instance.</returns>
        public ScheduMail.Core.Domain.WebSite GetById(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Saved Web site instance.</returns>
        public ScheduMail.Core.Domain.WebSite Save(ScheduMail.Core.Domain.WebSite entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="originalEntity">The original entity.</param>
        /// <returns>Updated WebSite instance.</returns>
        public ScheduMail.Core.Domain.WebSite Update(ScheduMail.Core.Domain.WebSite entity, ScheduMail.Core.Domain.WebSite originalEntity)
        {
            throw new NotImplementedException();
        }
       
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(ScheduMail.Core.Domain.WebSite entity)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IWebSiteRepository Members

        /// <summary>
        /// Gets the user E mails.
        /// </summary>
        /// <param name="webSiteId">The web site id.</param>
        /// <returns>List of User EMails.</returns>
        public IList<ScheduMail.Core.Domain.UserEMails> GetUserEMails(int webSiteId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
