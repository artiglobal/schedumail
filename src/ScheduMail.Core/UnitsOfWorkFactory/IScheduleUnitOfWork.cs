using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduMail.Core.Domain;

namespace ScheduMail.Core.UnitsOfWorkFactory
{
    /// <summary>
    /// Web Site Unit of Work interface
    /// </summary>
    public interface IScheduleUnitOfWork
    {
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The schedule list.</value>
        List<Schedule> List { get; }

        /// <summary>
        /// Saves the specified schedule.
        /// </summary>
        /// <param name="schedule">The schedule.</param>
        /// <returns>Schedule instance.</returns>
        ScheduMail.Core.Domain.Schedule Save(Schedule schedule);

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The identification.</param>
        /// <returns>Schedule instance.</returns>
        ScheduMail.Core.Domain.Schedule GetById(long id);

        /// <summary>
        /// Gets the by mail id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Schedule instance</returns>
        ScheduMail.Core.Domain.Schedule GetByMailId(long? MailId);

        /// <summary>
        /// Deletes the specified schedule.
        /// </summary>
        /// <param name="schedule">The schedule.</param>
        void Delete(Schedule schedule);
    }
}
