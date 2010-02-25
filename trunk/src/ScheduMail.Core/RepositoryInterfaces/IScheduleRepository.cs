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
        /// returns all the instance from database of schedules
        /// </summary>
        /// <returns>return as a list</returns>
        List<Schedule> GetAll();
    }
}
