using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduMail.Core.Domain;

namespace ScheduMail.Core.RepositoryInterfaces
{
    /// <summary>
    /// Provides a standard interface for Schedul operations
    /// </summary>
    public interface IScheduleRepository : ICrudRepository<Schedule, long>
    {
         /// <summary>
        /// Gets the by mail id.
        /// </summary>
        /// <param name="MailId">The mail id.</param>
        /// <returns>Schedule</returns>
        ScheduMail.Core.Domain.Schedule GetByMailId(long? MailId);

         /// <summary>
        /// Gets the list of schedule.
        /// </summary>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        /// <returns>list of schedule</returns>
        List<ScheduMail.Core.Domain.Schedule> GetListOfSchedule(bool enabled);
        
        
    }
}
