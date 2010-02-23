using System;
using System.Linq;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.DBModel;
using ScheduMail.Utils;

namespace ScheduMail.EFDal.Dal
{
    /// <summary>
    /// Log Event repository crud operations
    /// </summary>
    public class EFLogEventRepository : ILogEventRepository
    {
        #region Private Members

        /// <summary>
        /// ADO.net entity context handle
        /// </summary>
        private ScheduMailDBEntities context;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="EFLogEventRepository"/> class.
        /// </summary>
        public EFLogEventRepository()
        {
            this.context = new ScheduMailDBEntities();
        }

        #endregion

        #region ICrudRepository<LogEvent,long> Members

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The list value returned.</value>
        public IQueryable<ScheduMail.Core.Domain.LogEvent> List
        {
            get
            {
                return ObjectExtension
                          .CloneList<ScheduMail.DBModel.LogEvent,
                                ScheduMail.Core.Domain.LogEvent>
                                     (this.context.LogEvents.ToList<ScheduMail.DBModel.LogEvent>())                                     
                          .AsQueryable();
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The key value identification.</param>
        /// <returns>Found instance.</returns>
        public ScheduMail.Core.Domain.LogEvent GetById(long id)
        {
            var entity = this.context.LogEvents.Where(q => q.Id == id).First<ScheduMail.DBModel.LogEvent>();
            return ObjectExtension.CloneProperties<ScheduMail.DBModel.LogEvent, ScheduMail.Core.Domain.LogEvent>(entity);
        }

        /// <summary>
        /// Saves or Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Saved instance.</returns>
        public ScheduMail.Core.Domain.LogEvent Save(ScheduMail.Core.Domain.LogEvent entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Delete(ScheduMail.Core.Domain.LogEvent entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
