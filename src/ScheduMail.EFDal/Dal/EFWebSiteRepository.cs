using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.Core.Domain;
using ScheduMail.DBModel;

using ScheduMail.Utils;

namespace ScheduMail.EFDal.Dal
{
    /// <summary>
    /// Web site repository crud operations
    /// </summary>
    public class EFWebSiteRepository : IWebSiteRepository
    {
        #region ICrudRepository<WebSite,int> Members

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The list.</value>
        public IQueryable<ScheduMail.Core.Domain.WebSite> List
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Website instance.</returns>
        public ScheduMail.Core.Domain.WebSite GetById(int id)
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
            using (ScheduMailDBEntities context = new ScheduMailDBEntities())
            {
                ScheduMail.DBModel.WebSite webSite = 
                    ObjectExtension.CloneProperties<ScheduMail.Core.Domain.WebSite, ScheduMail.DBModel.WebSite>(entity);
                context.AddToWebSites(webSite);
                context.SaveChanges();

                return ObjectExtension.CloneProperties<ScheduMail.DBModel.WebSite, ScheduMail.Core.Domain.WebSite>(webSite);
            }            
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
    }
}
