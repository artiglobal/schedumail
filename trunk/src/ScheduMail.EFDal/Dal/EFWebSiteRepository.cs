using System.Linq;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.DBModel;
using ScheduMail.Utils;

namespace ScheduMail.EFDal.Dal
{
    /// <summary>
    /// Web site repository crud operations
    /// </summary>
    public class EFWebSiteRepository : IWebSiteRepository
    {
        #region Private Members

        /// <summary>
        /// ADO.net entity context handle
        /// </summary>
        private ScheduMailDBEntities context;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="EFWebSiteRepository"/> class.
        /// </summary>
        public EFWebSiteRepository()
        {
            this.context = new ScheduMailDBEntities();
        }

        #endregion

        #region ICrudRepository<WebSite,int> Members

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The list of web sites.</value>
        public IQueryable<ScheduMail.Core.Domain.WebSite> List
        {
            get
            {
                return ObjectExtension
                          .CloneList<ScheduMail.DBModel.WebSite,
                                ScheduMail.Core.Domain.WebSite>
                                     (this.context.WebSites.ToList<ScheduMail.DBModel.WebSite>())
                                     .OrderBy(q => q.SiteName)
                          .AsQueryable();
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The web siteid.</param>
        /// <returns>Website instance.</returns>
        public ScheduMail.Core.Domain.WebSite GetById(long id)
        {
            var entity = (from w in this.context.WebSites
                          where w.Id == id
                          select w).First();
            return ObjectExtension.CloneProperties<ScheduMail.DBModel.WebSite, ScheduMail.Core.Domain.WebSite>(entity);
        }

        /// <summary>
        /// Saves the specified web site.
        /// </summary>
        /// <param name="webSite">The web site.</param>
        /// <returns>Changed web site.</returns>
        public ScheduMail.Core.Domain.WebSite Save(ScheduMail.Core.Domain.WebSite webSite)
        {
            ScheduMail.DBModel.WebSite entity =
                ObjectExtension.CloneProperties<ScheduMail.Core.Domain.WebSite, ScheduMail.DBModel.WebSite>(webSite);

            if (webSite.IsNew())
            {
                this.context.AddToWebSites(entity);
                this.context.SaveChanges();
            }
            else
            {
                var originalWebSite = (from w in this.context.WebSites
                                       where w.Id == webSite.Id
                                       select w).First();

                this.context.ApplyPropertyChanges(originalWebSite.EntityKey.EntitySetName, entity);
                this.context.SaveChanges();
            }

            return ObjectExtension.CloneProperties<ScheduMail.DBModel.WebSite, ScheduMail.Core.Domain.WebSite>(entity);
        }

        /// <summary>
        /// Deletes the specified web site.
        /// </summary>
        /// <param name="webSite">The web site.</param>
        public void Delete(ScheduMail.Core.Domain.WebSite webSite)
        {
            var entity = (from w in this.context.WebSites
                          where w.Id == webSite.Id
                          select w).First();

            this.context.DeleteObject(entity);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Gets the user E mails.
        /// </summary>
        /// <param name="webSiteId">The web site id.</param>
        /// <returns>List of User EMails</returns>
        public IQueryable<ScheduMail.Core.Domain.WebSiteEMails> GetWebSiteEMails(long webSiteId)
        {
            var entities = from webSiteEmail in this.context.WebSites.Include("EMails")
                            join email in this.context.Mails on
                                webSiteEmail.Id equals email.WebSite.Id
                            join log in this.context.LogEvents on
                                email.Id equals log.Mail.Id
                            where webSiteEmail.Id == webSiteId
                            select new ScheduMail.Core.Domain.WebSiteEMails { EMailSubject = email.Subject, EmailId = email.Id, LastSent = email.LastSent, NextSend = email.NextSend, LogId = log.Id };

            return entities.AsQueryable<ScheduMail.Core.Domain.WebSiteEMails>();                
        }

        #endregion
    }
}
