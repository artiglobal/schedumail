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
    /// ASPNet Users Repository.
    /// </summary>
    public class EFAspNetUsersRepository : IASPNetUserRepository
    {
         #region Private Members

        /// <summary>
        /// ADO.net entity context handle
        /// </summary>
        private ScheduMailDBEntities context;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="EFAspNetUsersRepository"/> class.
        /// </summary>
        public EFAspNetUsersRepository()
        {
            this.context = new ScheduMailDBEntities();
        }

        #endregion

        #region ICrudRepository<ScheduMail,int> Members

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The list of users.</value>
        public IQueryable<ScheduMail.Core.Domain.AspnetUsers> List
        {
            get
            {
                return ObjectExtension
                          .CloneList<ScheduMail.DBModel.aspnet_Users,
                                ScheduMail.Core.Domain.AspnetUsers>
                                     (this.context.aspnet_Users.ToList<ScheduMail.DBModel.aspnet_Users>())
                                     .OrderBy(q => q.CreateDate)
                          .AsQueryable();
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The userid.</param>
        /// <returns>Website instance.</returns>
        public ScheduMail.Core.Domain.AspnetUsers GetById(string id)
        {
            var entity = (from w in this.context.aspnet_Users
                          where w.UserId == id
                          select w).First();
            return ObjectExtension.CloneProperties<ScheduMail.DBModel.aspnet_Users, ScheduMail.Core.Domain.AspnetUsers>(entity);
        }

        /// <summary>
        /// Lists the by web site id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>AspNetUser instance.</returns>
        public IQueryable<ScheduMail.Core.Domain.AspnetUsers> ListByWebSiteId(long id)
        {
            // Note heres an example of how to use an SQL Query J.I.C this doesn't work
            // context.CreateQuery(@"SELECT VALUE Customer FROM Customer 
            // WHERE EXISTS( SELECT VALUE FROM CustomerInterest 
            // WHERE CustomerInterest.Ineterest.Name = 'FootBall')).Include("Interest");
            var users = (from w in this.context.WebSites
                         from u in w.aspnet_Users
                         where w.Id == id
                         select u).ToList<ScheduMail.DBModel.aspnet_Users>();                              

            return ObjectExtension
                      .CloneList<ScheduMail.DBModel.aspnet_Users,
                            ScheduMail.Core.Domain.AspnetUsers>
                                 (users)
                                 .OrderBy(q => q.CreateDate)
                      .AsQueryable();
        }

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="webSite">The user.</param>
        /// <returns>Changed user.</returns>
        public ScheduMail.Core.Domain.AspnetUsers Save(ScheduMail.Core.Domain.AspnetUsers webSite)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified user.
        /// </summary>
        /// <param name="webSite">The user.</param>
        public void Delete(ScheduMail.Core.Domain.AspnetUsers user)
        {
            var entity = (from u in this.context.aspnet_Users
                          where u.UserId == user.UserId
                          select u).First();

            this.context.DeleteObject(entity);
            this.context.SaveChanges();
        }    
   
        #endregion
    }
}
