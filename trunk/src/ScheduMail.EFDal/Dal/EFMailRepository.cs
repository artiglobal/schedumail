using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.DBModel;
using ScheduMail.Utils;

namespace ScheduMail.EFDal.Dal
{
    /// <summary>
    /// EMail repository.
    /// </summary>
    public class EFMailRepository : IMailRespository
    {
         #region Private Members

        /// <summary>
        /// ADO.net entity context handle
        /// </summary>
        private ScheduMailDBEntities context;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="EFMailRepository"/> class.
        /// </summary>
        public EFMailRepository()
        {
            this.context = new ScheduMailDBEntities();
        }

        #endregion

        #region ICrudRepository<Mail,int> Members

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The list of web sites.</value>
        public IQueryable<ScheduMail.Core.Domain.Mail> List
        {
            get
            {
                return ObjectExtension
                          .CloneList<ScheduMail.DBModel.Mail,
                                ScheduMail.Core.Domain.Mail>
                                     (this.context.Mails.ToList<ScheduMail.DBModel.Mail>())
                                     .OrderBy(q => q.CreatedBy)
                          .AsQueryable();
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The web siteid.</param>
        /// <returns>Website instance.</returns>
        public ScheduMail.Core.Domain.Mail GetById(long id)
        {
            var entity = (from w in this.context.Mails
                          where w.Id == id
                          select w).First();
            return ObjectExtension.CloneProperties<ScheduMail.DBModel.Mail, ScheduMail.Core.Domain.Mail>(entity);
        }

        /// <summary>
        /// Saves the specified web site.
        /// </summary>
        /// <param name="webSite">The web site.</param>
        /// <returns>Changed web site.</returns>
        public ScheduMail.Core.Domain.Mail Save(ScheduMail.Core.Domain.Mail webSite)
        {
            ScheduMail.DBModel.Mail entity =
                ObjectExtension.CloneProperties<ScheduMail.Core.Domain.Mail, ScheduMail.DBModel.Mail>(webSite);

            if (webSite.IsNew())
            {
                this.context.AddToMails(entity);
                this.context.SaveChanges();
            }
            else
            {
                var originalMail = (from w in this.context.Mails
                                       where w.Id == webSite.Id
                                       select w).First();

                this.context.ApplyPropertyChanges(originalMail.EntityKey.EntitySetName, entity);
                this.context.SaveChanges();
            }

            return ObjectExtension.CloneProperties<ScheduMail.DBModel.Mail, ScheduMail.Core.Domain.Mail>(entity);
        }

        /// <summary>
        /// Deletes the specified web site.
        /// </summary>
        /// <param name="webSite">The web site.</param>
        public void Delete(ScheduMail.Core.Domain.Mail webSite)
        {
            var entity = (from w in this.context.Mails
                          where w.Id == webSite.Id
                          select w).First();

            this.context.DeleteObject(entity);
            this.context.SaveChanges();
        }    
   
        #endregion
    }
}
