using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using ScheduMail.Core.RepositoryInterfaces;
using ScheduMail.Core.UnitsOfWorkFactory;

namespace ScheduMail.UnitsOfWork
{
    /// <summary>
    /// Web site unit of work.
    /// </summary>
    public class ScheduleUnitOfWork : IScheduleUnitOfWork
    {
        #region IScheduleUnitOfWork Members

        /// <summary>
        /// Repository handle.
        /// </summary>
        private IScheduleRepository repository;

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>The repository.</value>
        public IScheduleRepository Repository
        {
            get { return this.repository; }
            set { this.repository = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebSiteUnitOfWork"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public ScheduleUnitOfWork(IScheduleRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The Web site list.</value>
        public List<ScheduMail.Core.Domain.Schedule> List
        {
            get
            {
                return this.repository.List.ToList();
            }
        }

        /// <summary>
        /// Get a Schedule instance by id.
        /// </summary>
        /// <param name="id">The Web Site instance id.</param>
        /// <returns>Web Site instance.</returns>
        public ScheduMail.Core.Domain.Schedule GetById(long id)
        {
            return this.repository.GetById(id);
        }

        /// <summary>
        /// Saves the specified web site.
        /// </summary>
        /// <param name="schedule">The web site.</param>
        /// <returns>Updated Web site instance.</returns>
        public ScheduMail.Core.Domain.Schedule Save(ScheduMail.Core.Domain.Schedule schedule)
        {
            var errors = this.GetRuleViolations(schedule);
            if (errors.Count > 0)
            {
                throw new RuleException(errors);
            }

            return this.repository.Save(schedule);
        }

        /// <summary>
        /// Deletes the specified web site.
        /// </summary>
        /// <param name="schedule">The web site.</param>
        public void Delete(ScheduMail.Core.Domain.Schedule schedule)
        {
            this.repository.Delete(schedule);
        }

        /// <summary>
        /// Gets the rule violations.
        /// </summary>
        /// <param name="schedule">The web site.</param>
        /// <returns>Collection of Rules Violations.</returns>
        private NameValueCollection GetRuleViolations(ScheduMail.Core.Domain.Schedule schedule)
        {
            var errors = new NameValueCollection();

            if (schedule.StartDateTime != null)
            {
                errors.Add("StartDateTime", "Start date is required");
            }

            if (schedule.EndDateTime != null)
            {
                errors.Add("StartDateTime", "End date is required");
            }

            if (string.IsNullOrEmpty(schedule.DailyWeeklyOrMonthly))
            {
                errors.Add("DailyWeeklyOrMonthly", "Please check the time to run");
            }

            if (string.IsNullOrEmpty(schedule.DaysOfWeekToRun))
            {
                errors.Add("DailyWeeklyOrMonthly", "Please check days of the week");
            }

            return errors;
        }

        #endregion
    }
}
