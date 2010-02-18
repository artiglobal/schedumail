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
        /// <value>The list.</value>
        public IQueryable<ScheduMail.DBModel.WebSite> List
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Website instance.</returns>
        public ScheduMail.DBModel.WebSite GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Saved Web site instance.</returns>
        public ScheduMail.DBModel.WebSite Save(ScheduMail.DBModel.WebSite entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="originalEntity">The original entity.</param>
        /// <returns>Updated WebSite instance.</returns>
        public ScheduMail.DBModel.WebSite Update(ScheduMail.DBModel.WebSite entity, ScheduMail.DBModel.WebSite originalEntity)
        {
            throw new NotImplementedException();
        }
       
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(ScheduMail.DBModel.WebSite entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
