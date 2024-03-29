﻿using System.Linq;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.DBModel;
using ScheduMail.Utils;
using System.Collections.Generic;

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
                entity.Mail = (from w in this.context.Mails
                               where w.Id == schedule.MailId
                               select w).FirstOrDefault();
                this.context.AddToSchedules(entity);
                this.context.SaveChanges();
            }
            else
            {
                var originalWebSite = (from w in this.context.Schedules
                                       join mails in this.context.Mails on
                                       schedule.MailId equals mails.Id
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
                          select w).FirstOrDefault();
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

        /// <summary>
        /// Gets the by mail id.
        /// </summary>
        /// <param name="MailId">The mail id.</param>
        /// <returns>Schedule</returns>
        public ScheduMail.Core.Domain.Schedule GetByMailId(long? MailId)
        {
            var entity = (from w in this.context.Schedules
                          where w.Mail.Id == MailId
                          select w).FirstOrDefault();
            return ObjectExtension.CloneProperties<ScheduMail.DBModel.Schedule, ScheduMail.Core.Domain.Schedule>(entity);

        }




        /// <summary>
        /// Gets the list of schedule.
        /// </summary>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        /// <returns>list of schedule</returns>
        public List<ScheduMail.Core.Domain.Schedule> GetListOfSchedule(bool enabled)
        {
            var entity = (from w in this.context.Schedules.Include("Mail")
                          where w.Enabled == enabled
                          select w).ToList();
            ScheduMail.Core.Domain.Schedule objSchedule = null;
            List<ScheduMail.Core.Domain.Schedule> ListofSchedules = new List<ScheduMail.Core.Domain.Schedule>();

            foreach (ScheduMail.DBModel.Schedule schedule in entity)
            {
                objSchedule = new ScheduMail.Core.Domain.Schedule();
                objSchedule.Id = schedule.Id;
                objSchedule.StartDateTime = schedule.StartDateTime;
                objSchedule.EndDateTime = schedule.EndDateTime;
                objSchedule.Enabled = schedule.Enabled;
                objSchedule.DaysOfWeekToRun = schedule.DaysOfWeekToRun;
                objSchedule.DailyWeeklyOrMonthly = schedule.DailyWeeklyOrMonthly;
                objSchedule.Created = schedule.Created;
                objSchedule.Modified = schedule.Modified;
                objSchedule.ModifiedBy = schedule.ModifiedBy;
                objSchedule.MailId = schedule.Mail.Id;
                ListofSchedules.Add(objSchedule);
            }
            return ListofSchedules;
                  
        }


     
        #endregion      
    }
}
