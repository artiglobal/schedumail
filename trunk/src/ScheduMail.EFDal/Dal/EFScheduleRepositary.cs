using System.Linq;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.DBModel;
using ScheduMail.Utils;

namespace ScheduMail.EFDal.Dal
{
    /// <summary>
    /// Web site repository crud operations for Schedule
    /// </summary>
    public class EFScheduleRepositary : IScheduleRepository
    {
        #region Private Members

        /// <summary>
        /// ADO.net entity context handle
        /// </summary>
        private ScheduMailDBEntities context;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="EFScheduleRepositary"/> class.
        /// </summary>
        public EFScheduleRepositary()
        {
            this.context = new ScheduMailDBEntities();
        }

        #endregion

        #region IScheduleRepository Members

        /// <summary>
        /// Saves the specified schedule.
        /// </summary>
        /// <param name="schedule">The schedule.</param>
        /// <returns>Changed schedule.</returns>
        public ScheduMail.Core.Domain.Schedule Save(ScheduMail.Core.Domain.Schedule schedule)
        {
            ScheduMail.DBModel.Schedule entity =
                ObjectExtension.CloneProperties<ScheduMail.Core.Domain.Schedule, ScheduMail.DBModel.Schedule>(schedule);

            if (schedule.IsNew())
            {
                this.context.AddToSchedules(entity);
                this.context.SaveChanges();
            }
            else
            {
                var originalWebSite = (from w in this.context.Schedules
                                       where w.Id == schedule.Id
                                       select w).First();

                this.context.ApplyPropertyChanges(originalWebSite.EntityKey.EntitySetName, entity);
                this.context.SaveChanges();
            }

            return ObjectExtension.CloneProperties<ScheduMail.DBModel.Schedule, ScheduMail.Core.Domain.Schedule>(entity);
        }   

        /// <summary>
        /// Deletes the specified web site.
        /// </summary>
        /// <param name="schedules">The schedule.</param>
        public void Delete(ScheduMail.Core.Domain.Schedule schedules)
        {
            var entity = (from w in this.context.Schedules
                          where w.Id == schedules.Id
                          select w).First();

            this.context.DeleteObject(entity);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Returnts the object of  Schedule from ID
        /// </summary>
        /// <param name="id">id of the schedule to return</param>
        /// <returns>object of Schedule</returns>
        public ScheduMail.Core.Domain.Schedule GetById(long id)
        {
            var entity = (from w in this.context.Schedules
                          where w.Id == id
                          select w).First();
            return ObjectExtension.CloneProperties<ScheduMail.DBModel.Schedule, ScheduMail.Core.Domain.Schedule>(entity);
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The list of Schedule.</value>
        public IQueryable<ScheduMail.Core.Domain.Schedule> List
        {
            get
            {
                return ObjectExtension
                          .CloneList<ScheduMail.DBModel.Schedule,
                                ScheduMail.Core.Domain.Schedule>
                                     (this.context.Schedules.ToList<ScheduMail.DBModel.Schedule>()).AsQueryable();
            }
        }
     
        #endregion      
    }
}
